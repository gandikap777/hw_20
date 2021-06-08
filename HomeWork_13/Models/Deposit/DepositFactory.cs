using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    class DepositFactory
    {
        /// <summary>
        /// Создание экземпляра вклада по типу
        /// </summary>
        /// <param name="TypeDeposit"></param>
        /// <param name="DateOpen"></param>
        /// <param name="Period"></param>
        /// <param name="Summ"></param>
        /// <param name="Capitalization"></param>
        /// <param name="Rate"></param>
        /// <param name="IdClient"></param>
        /// <returns></returns>
        public static IDeposit GetDeposit(string TypeDeposit,
                                          DateTime DateOpen, 
                                          int Period,
                                          double Summ, 
                                          bool Capitalization, 
                                          int Rate, 
                                          int IdClient)
        {
            switch (TypeDeposit)
            {
                case "Basic": return new BasicDeposit(DateOpen, Period, Summ, Capitalization, Rate, IdClient);
                default: return new NullDeposit();
            }
        }
    }
}
