using HomeWork_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Service
{
    public static class ServiceType
    {
        public static Dictionary<string, string> GetServiceTypes()
        {
            Dictionary<string, string> ServiceTypes = new Dictionary<string, string>();

            ServiceTypes.Add("МонтажныеРаботы"      , "Монтажные работы");
            ServiceTypes.Add("ДемонтажныеРаботы"    , "Работы по демонтажу");
            ServiceTypes.Add("МалярныеРаботы"       , "Молярные работы");
            ServiceTypes.Add("ПлиточныеРаботы"      , "Плиточные работы");
            ServiceTypes.Add("ПлотницкиеРаботы"     , "Плотницкие работы");

            return ServiceTypes;
        }
    }
    public static class GetData
    {
        public static Dictionary<int, string> GetDataAccounts(IEnumerable<IAccount> accounts)
        {
            Dictionary<int, string> acc = new Dictionary<int, string>();

            foreach (IAccount item in accounts)
            {
                acc.Add(item.ID, item.ToString());
            }

            return acc;
        }
    }

    public static class DepositRate
    {
        public static Dictionary<int, string> GetDepositRate(IClient client)
        {
            Dictionary<int, string> rates = new Dictionary<int, string>();

            rates.Add(7, "7%");

            if (client.GoodCreditHistory)
                rates.Add(8, "8%");

            return rates;
        }
    }

    public static class DepositPeriod
    {
        public static Dictionary<int, string> GetDepositPeriod(IClient client)
        {
            Dictionary<int, string> periods = new Dictionary<int, string>();

            periods.Add(3, "3 месяца");
            periods.Add(6, "6 месяцев");
            periods.Add(9, "9 месяцев");
            periods.Add(12, "1 год");
            periods.Add(18, "18 месяцев");
            periods.Add(24, "2 года");

            if (client.GoodCreditHistory)
                periods.Add(36, "3 года");

            return periods;
        }
    }


    public class BalanceTransferBody
    {
        public int fromid { get; set; }
        public int toid { get; set; }
        public double summ { get; set; }
    }

    public class ChangeBalanceBody
    {
        public int id { get; set; }
        public double summ { get; set; }
    }

    public class DepositBody
    {
        public int fromid { get; set; }
        public int toid { get; set; }
        public double summ { get; set; }
    }

}
