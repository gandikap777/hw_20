﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    class ClientModel : IClientModel
    {
        private string SelectedItemIdText;
        private string SelectedAccountIdText;
        private string AccountToIdText;
        private string SummText;
        private bool Capitalization;
        private string PeriodText;
        private string RateText;
        private string DateOpenText;

        public ClientModel()
        {

        }

        /// <summary>
        /// Получение данных для открытия вклада
        /// </summary>
        /// <param name="SlelctedItemId"></param>
        /// <param name="SelectedAccountId"></param>
        /// <param name="Summ"></param>
        /// <param name="Capitalization"></param>
        /// <param name="Rate"></param>
        /// <param name="DateOpen"></param>
        /// <param name="Period"></param>
        void IClientModel.GetDataDeposit(string SlelctedItemId, string SelectedAccountId, string Summ, bool Capitalization, string Rate, string DateOpen, string Period)
        {
            this.SelectedItemIdText = SlelctedItemId;
            this.SelectedAccountIdText = SelectedAccountId;
            this.SummText = Summ;
            this.Capitalization = Capitalization;
            this.RateText = Rate;
            this.PeriodText = Period;
            this.DateOpenText = DateOpen;
        }

        private int SelectedItemId;
        private int SelectedAccountId;
        private int AccountToId;
        private DateTime DateOpen;
        private double Summ;
        private int Rate;
        private int Period;
        private string TypeAccount;
        private string TypeDeposit;

        /// <summary>
        /// Открытие счета клиента
        /// </summary>
        /// <returns></returns>
        bool IClientModel.CreateAccount()
        {
            Context_18 db = new Context_18();
            if (!Int32.TryParse(this.SelectedItemIdText, out SelectedItemId)) { throw new FormatException("Неверно указан ИД клиента"); }

            if (!Double.TryParse(this.SummText, out Summ)) { throw new FormatException("Неверно указана сумма"); }

            TypeAccount = "Basic";

            IAccount acc = AccountFactory.GetAccount(TypeAccount, SelectedItemId, Summ);

            db.Accounts.Add((Account)acc);

            db.SaveChanges();

            db.Dispose();

            return true;
        }

        /// <summary>
        /// Открытие депозита клиента
        /// </summary>
        /// <returns></returns>
        bool IClientModel.CreateDeposit()
        {
            Context_18 db = new Context_18();


            if (!Double.TryParse(this.SummText, out Summ)) throw new CustomException($"Не корректно введена сумма!", 10_212);

            if (Summ == 0) throw new CustomException($"Введите сумму вклада!", 10_212);

            if (Summ < 0) throw new CustomException($"Сумма должна быть больше 0!", 10_202);

            if (!Int32.TryParse(this.SelectedItemIdText, out SelectedItemId)) { throw new FormatException("Неверно указан ИД клиента"); }

            if (!Int32.TryParse(this.SelectedAccountIdText, out SelectedAccountId)) { throw new FormatException("Неверно указан ИД аккаунта"); }

            Account SelectedAccount = db.Accounts.Where(x => x.ID == SelectedAccountId).FirstOrDefault();
            SelectedAccount.WriteMessage += db.WriteMessage;

            if (SelectedAccount.Balance < Summ) throw new CustomException($"Недостаточно баланса на счете", 10_202);

            SelectedAccount.DecreaseBalance(Summ);
            
            Int32.TryParse(this.PeriodText, out Period);

            Int32.TryParse(this.RateText, out Rate);

            if (!DateTime.TryParse(this.DateOpenText, out DateOpen)) { throw new FormatException("Неверно указана дата открытия вклада"); }

            TypeDeposit = "Basic";

            IDeposit dep = DepositFactory.GetDeposit(TypeDeposit, DateOpen, Period, Summ, Capitalization, Rate, SelectedItemId);

            dep.WriteMessage += db.WriteMessage;

            dep.OpenDeposit();

            db.Deposits.Add((Deposit)dep);

            db.SaveChanges();

            db.Dispose();

            return true;
        }

        /// <summary>
        /// Получение данных для открытия счета
        /// </summary>
        /// <param name="SlelctedItemId"></param>
        /// <param name="Summ"></param>
        void IClientModel.GetDataAccount(string SlelctedItemId, string Summ)
        {
            this.SelectedItemIdText = SlelctedItemId;
            this.SummText = Summ;
        }

        /// <summary>
        /// Перевод ДС между счетами
        /// </summary>
        /// <returns></returns>
        bool IClientModel.Transfer()
        {
            Context_18 db = new Context_18();

            if (String.IsNullOrEmpty(SelectedAccountIdText)) throw new CustomException($"Выберите счет с которого выполнить перевод!", 10_100);            

            if (!Int32.TryParse(this.SelectedAccountIdText, out SelectedAccountId)) throw new CustomException($"Не корректно указан счет Отправителя!", 10_109);

            if (!Int32.TryParse(this.AccountToIdText, out AccountToId)) throw new CustomException($"Не корректно указан счет получателя!", 10_109);

            if (!Double.TryParse(this.SummText, out Summ)) throw new CustomException($"Не корректно указана сумма перевода!", 10_108);

            if (SelectedAccountId == AccountToId) throw new CustomException($"Запрещено переводить на этот же счет!", 10_102);
            

            if (!db.Accounts.Any(x => x.ID == AccountToId)) throw new CustomException($"Не найден счет получатель {AccountToId}", 10_001);

            Account AccountTo = db.Accounts.Where(x => x.ID == AccountToId).FirstOrDefault();
            AccountTo.WriteMessage += db.WriteMessage;


            Account AccountFrom = db.Accounts.Where(x => x.ID == SelectedAccountId).FirstOrDefault();
            AccountFrom.WriteMessage += db.WriteMessage;

            if (AccountFrom.Balance < Summ) throw new CustomException($"Не достаточно суммы на {SelectedAccountId} для перевода {Summ}", 10_002);

            AccountFrom.DecreaseBalance(Summ);

            AccountTo.IncreaseBalance(Summ);

            TransactionLog.WriteTransactionLog($"Перевод денежных средств со счета {SelectedAccountId} на счета {AccountToId}. Сумма {Summ}", "default.log");

            db.SaveChanges();

            db.Dispose();

            return true;
        }

        /// <summary>
        /// Пополнение баланса счета
        /// </summary>
        /// <returns></returns>
        bool IClientModel.TopUpBalance()
        {
            Context_18 db = new Context_18();

            if (String.IsNullOrEmpty(SelectedAccountIdText)) throw new CustomException($"Не выбран получатель!", 10_205);

            if (!Double.TryParse(this.SummText, out Summ)) throw new CustomException($"Не корректно указана сумма!", 10_212);

            if (!Int32.TryParse(this.SelectedAccountIdText, out SelectedAccountId)) throw new CustomException($"Не корректно указан счет Отправителя!", 10_109);

            if (Summ < 0) throw new CustomException($"Сумма должна быть больше 0!", 10_202);

            Account acc = db.Accounts.Where(x => x.ID == SelectedAccountId).FirstOrDefault();

            acc.WriteMessage += db.WriteMessage;

            acc.IncreaseBalance(Summ);

            db.SaveChanges();

            db.Dispose();

            return true;

        }

        /// <summary>
        /// Получение данных для перевода
        /// </summary>
        /// <param name="SelectedAccountId"></param>
        /// <param name="AccountToId"></param>
        /// <param name="Summ"></param>
        void IClientModel.GetDataTransfer(string SelectedAccountId, string AccountToId, string Summ)
        {
            this.SelectedAccountIdText = SelectedAccountId;
            this.AccountToIdText = AccountToId;
            this.SummText = Summ;
        }

        /// <summary>
        /// Получение данных для пополнения счета
        /// </summary>
        /// <param name="SelectedAccountId"></param>
        /// <param name="Summ"></param>
        void IClientModel.GetDataTopUpBalance(string SelectedAccountId, string Summ)
        {
            this.SelectedAccountIdText = SelectedAccountId;
            this.SummText = Summ;
        }

        /// <summary>
        /// Получение счетов клиента
        /// </summary>
        /// <param name="SelectedItemIdText"></param>
        /// <returns></returns>
        IEnumerable<Account> IClientModel.GetAccounts(string SelectedItemIdText)
        {
            if (!Int32.TryParse(SelectedItemIdText, out SelectedItemId)) throw new CustomException($"Не корректно указан счет Отправителя!", 10_109);
            Context_18 db = new Context_18();

            var accounts = db.Accounts.Where(x => x.IdClient == SelectedItemId).ToList();

            return accounts;
        }

        /// <summary>
        /// Получение списка депозитов клиента
        /// </summary>
        /// <param name="SelectedItemIdText"></param>
        /// <returns></returns>
        IEnumerable<Deposit> IClientModel.GetDeposits(string SelectedItemIdText)
        {
            if (!Int32.TryParse(SelectedItemIdText, out SelectedItemId)) throw new CustomException($"Не корректно указан счет Отправителя!", 10_109);
            Context_18 db = new Context_18();

            var deposits = db.Deposits.Where(x => x.IdClient == SelectedItemId).ToList();

            db.Dispose();

            return deposits;
        }

        /// <summary>
        /// Получение списка сообщений клиента
        /// </summary>
        /// <param name="SelectedItemIdText"></param>
        /// <returns></returns>
        IEnumerable<Messages> IClientModel.GetMessages(string SelectedItemIdText)
        {
            if (!Int32.TryParse(SelectedItemIdText, out SelectedItemId)) throw new CustomException($"Не корректно указан счет Отправителя!", 10_109);
            Context_18 db = new Context_18();

            var messages = db.Messages.Where(x => x.IdClient == SelectedItemId).ToList();

            db.Dispose();

            return messages;
        }

        /// <summary>
        /// Установка заголовка окна
        /// </summary>
        /// <param name="SelectedItemIdText"></param>
        /// <returns></returns>
        string IClientModel.GetTittle(string SelectedItemIdText)
        {
            Context_18 db = new Context_18();

            if (!Int32.TryParse(SelectedItemIdText, out SelectedItemId)) throw new CustomException($"Не корректно указан счет Отправителя!", 10_109);

            if (db.Persons.Any(x => x.ID == SelectedItemId))
            {
                Person client = db.Persons.Where(x => x.ID == SelectedItemId).FirstOrDefault();

                string tmp = "";

                tmp += client.GoodCreditHistory ? $" (Хорошая кредитная история)" : String.Empty;

                tmp =  $"{client.FullName}{tmp}";
                return tmp;
            }

            return "";

        }

        /// <summary>
        /// Получение списка ставок для вклада
        /// </summary>
        /// <param name="SelectedItemIdText"></param>
        /// <returns></returns>
        IEnumerable<string> IClientModel.GetRate(string SelectedItemIdText)
        {
            List<string> rate = new List<string>();
            Context_18 db = new Context_18();

            rate.Add("7");

            if (!Int32.TryParse(SelectedItemIdText, out SelectedItemId)) throw new CustomException($"Не корректно указан счет Отправителя!", 10_109);

            if (db.Persons.Any(x => x.ID == SelectedItemId))
            {
                Person client = db.Persons.Where(x => x.ID == SelectedItemId).FirstOrDefault();

                if (client.GoodCreditHistory) rate.Add("8");
            }

            return rate;
        }

        /// <summary>
        /// Получение счетов клиента для вклада
        /// </summary>
        /// <param name="SelectedItemIdText"></param>
        /// <returns></returns>
        IEnumerable<string> IClientModel.GetAccountsComboBox(string SelectedItemIdText)
        {
            ObservableCollection<string> accounts = new ObservableCollection<string>();

            if (!Int32.TryParse(SelectedItemIdText, out SelectedItemId)) throw new CustomException($"Не корректно указан счет Отправителя!", 10_109);
            Context_18 db = new Context_18();

            foreach (Account item in db.Accounts.Where(x => x.IdClient == SelectedItemId))
            {
                accounts.Add(item.ID.ToString());
            }

            return accounts;
        }

        /// <summary>
        /// Получение периодов для вклада
        /// </summary>
        /// <param name="SelectedItemId"></param>
        /// <returns></returns>
        IEnumerable<string> IClientModel.GetPeriod(string SelectedItemId)
        {
            ObservableCollection<string> periods = new ObservableCollection<string>();

            periods.Add(1.ToString());
            periods.Add(3.ToString());
            periods.Add(6.ToString());
            periods.Add(9.ToString());
            periods.Add(12.ToString());
            
            return periods;
        }
    }
}
