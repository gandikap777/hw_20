using HomeWork_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Presenters
{
    class ClientPresenter
    {
        IClientView view;
        IClientModel model;

        public ClientPresenter(IClientView clientView)
        {
            this.view = clientView;

            model = new ClientModel();

            LoadRate(view.SelectedItemId);

            LoadPeriods(view.SelectedItemId);
                      
            UpdateInterface();
        }

        /// <summary>
        /// Обновление интерфейса приложения
        /// </summary>
        void UpdateInterface()
        {
            view.LoadAccounts(model.GetAccounts(view.SelectedItemId));

            view.LoadDeposits(model.GetDeposits(view.SelectedItemId));

            view.LoadMessages(model.GetMessages(view.SelectedItemId));

            view.LoadAccountsComboBox(model.GetAccountsComboBox(view.SelectedItemId));
        }

        /// <summary>
        /// Создание аккаунта
        /// </summary>
        public void CreateAccount()
        {
            model.GetDataAccount(view.SelectedItemId, "0");
            
            view.Result = model.CreateAccount();

            UpdateInterface();
        }

        /// <summary>
        /// Открытие вклада
        /// </summary>
        public void CreateDeposit()
        {
            model.GetDataDeposit(view.SelectedItemId, view.ComboBoxAccountId, view.CountDeposit, view.Capitalization, view.Rate, view.Dateopen, view.Period);

            view.Result = model.CreateDeposit();

            UpdateInterface();
        }

        /// <summary>
        /// Перевод ДС
        /// </summary>
        public void Transfer()
        {
            model.GetDataTransfer(view.SelectedAccountId, view.AccountToId, view.Count);

            view.Result = model.Transfer();
            
            UpdateInterface();
        }

        /// <summary>
        /// Пополнение ДС
        /// </summary>
        public void TopUpBalance()
        {
            model.GetDataTopUpBalance(view.SelectedAccountId, view.CountUp);

            view.Result = model.TopUpBalance();

            UpdateInterface();
        }

        /// <summary>
        /// Загрузка списка аккаунтов
        /// </summary>
        public void LoadAccounts()
        {
            view.LoadAccounts(model.GetAccounts(view.SelectedItemId));
        }

        /// <summary>
        /// Загрузка списка депозитов
        /// </summary>
        public void LoadDeposits()
        {
            view.LoadDeposits(model.GetDeposits(view.SelectedItemId));
        }

        /// <summary>
        /// Загрузка списка сообщений
        /// </summary>
        public void LoadMessages()
        {
            view.LoadMessages(model.GetMessages(view.SelectedItemId));
        }

        /// <summary>
        /// установка заголовка окна
        /// </summary>
        /// <param name="SelectedItemId"></param>
        public void Loaded(string SelectedItemId)
        {
            view.Tittle = model.GetTittle(SelectedItemId);
        }

        /// <summary>
        /// Загрузка ставок
        /// </summary>
        /// <param name="SelectedItemId"></param>
        public void LoadRate(string SelectedItemId)
        {
            view.LoadRate(model.GetRate(SelectedItemId));
        }

        /// <summary>
        /// Загрузка счетов
        /// </summary>
        /// <param name="SelectedItemId"></param>
        public void LoadAccountsComboBox(string SelectedItemId)
        {
            view.LoadAccountsComboBox(model.GetAccountsComboBox(SelectedItemId));
        }

        /// <summary>
        /// Загрузка периодов для вклада
        /// </summary>
        /// <param name="SelectedItemId"></param>
        public void LoadPeriods(string SelectedItemId)
        {
            view.LoadPeriod(model.GetPeriod(SelectedItemId));
        }
    }
}
