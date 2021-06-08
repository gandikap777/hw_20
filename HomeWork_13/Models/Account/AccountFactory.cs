using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    static class AccountFactory
    {
        /// <summary>
        /// Создание экземпляра счета по типу
        /// </summary>
        /// <param name="TypeAccount"></param>
        /// <param name="IdClient"></param>
        /// <param name="Summ"></param>
        /// <returns></returns>
        public static IAccount GetAccount(string TypeAccount,
                                          int IdClient,
                                          double Summ)
        {
            switch (TypeAccount)
            {
                case "Basic": return new BasicAccount(IdClient, Summ);
                default: return new NullAccount();
            }
        }
    }
}
