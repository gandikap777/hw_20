using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_15_Library;

namespace HomeWork_13
{

    abstract public class Deposit : Models.IDeposit
    {

        /// <summary>
        /// Идентификатор 
        /// </summary>
        private int id;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int ID
        {
            get => id;
            set => id = value;
        }

        /// <summary>
        /// Событие сообщений по депозиту
        /// </summary>
        public event Action<int, string> WriteMessage;

        public Deposit() { }

        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        private int idclient;

        public int IdClient
        {
            get { return idclient; }
            set { idclient = value; }
        }

        /// <summary>
        /// Сумма вклада
        /// </summary>
        private double summ;

        public double Summ
        {
            get => summ; 
            set => summ = value; 
        }

        /// <summary>
        /// дата открытия вклада
        /// </summary>
        private DateTime dateopen;

        public DateTime DateOpen
        {
            get => dateopen; 
            set => dateopen = value; 
        }


        /// <summary>
        /// Срок вклада
        /// </summary>
        private int period;

        public int Period
        {
            get => period; 
            set => period = value; 
        }

        /// <summary>
        /// Капитализация
        /// </summary>
        private bool capitalization;

        public bool Capitalization
        {
            get => capitalization; 
            set => capitalization = value; 
        }

        /// <summary>
        /// Ставка
        /// </summary>
        private int rate;

        public int Rate
        {
            get => rate; 
            set => rate = value; 
        }
        /// <summary>
        /// Итоговая сумма депозита
        /// </summary>
        public double Outcome
        {
            get
            {
                double balanceDeposit = Summ;
                if (!Capitalization)
                {
                    return CustomCalculation.CalculateWithoutCapitalization(balanceDeposit, (uint)Period, Rate);
                }
                else
                {
                    return CustomCalculation.CalculateWithCapitalization(balanceDeposit, (uint)Period, Rate);
                }

            }
        }

        /// <summary>
        /// Метод записывает лог по открытому депозиту
        /// </summary>
        /// <returns></returns>
        public bool OpenDeposit()
        {
                        
            string msg = $"Открыт вклад сумма {summ} до {DateTime.Now.AddMonths((int)period).ToString("D")}";
            WriteMessage?.Invoke(idclient, msg);
            msg.Log();
            return true;
        }


        public Deposit(DateTime DateOpen, int Period, double Summ, bool Capitalization, int Rate, int IdClient)
        {

            this.Period = Period;
            this.Summ = Summ;
            this.Rate = Rate;
            this.capitalization = Capitalization;
            this.idclient = IdClient;
            this.dateopen = DateOpen;
        }


    }
}
