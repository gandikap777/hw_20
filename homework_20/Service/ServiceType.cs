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
}
