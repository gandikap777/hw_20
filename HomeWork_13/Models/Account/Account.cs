using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    abstract public class Account : INotifyPropertyChanged, Models.IAccount
    {

        public event Action<int, string> WriteMessage;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// ключ
        /// </summary>
        private int id;

        public Account() { }

        public Account(int IdClient, double Summ)
        {

            this.Balance = Summ;
            this.idclient = IdClient;
        }

        /// <summary>
        /// уникальный номер счета
        /// </summary>
        public int ID
        {
            get { return id; }
            set 
            { 
                id = value;
            }
        }

        /// <summary>
        /// Сумма на счете
        /// </summary>
        private double balance;

        /// <summary>
        /// Баланс
        /// </summary>
        public double Balance
        {
            get { return balance; }
            set 
            {
                balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }


        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        private int idclient;

        public int IdClient
        {
            get => idclient;
            set => idclient = value;
        }


        /// <summary>
        /// Метод пополняет балано
        /// </summary>
        /// <param name="Summ"></param>
        public void IncreaseBalance(double Summ)
        {
            this.Balance += Summ;
            WriteMessage?.Invoke(idclient, $"Баланс счета {this.ID} пополнен на сумму {Summ} рублей.");
        }
        
        /// <summary>
        /// Метод уменьшает баланс
        /// </summary>
        /// <param name="Summ"></param>
        public void DecreaseBalance(double Summ)
        {
            this.Balance -= Summ;
            WriteMessage?.Invoke(idclient, $"Баланс счета {this.ID} уменьшен на сумму {Summ} рублей.");
        }

        public static double operator +(double s, Account e)
        {
            return s + e.Balance;
        }

        /// <summary>
        /// реализация интерфейса INotifyPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override string ToString()
        {
            return $"Счет № {this.ID}";
        }
    }


}
