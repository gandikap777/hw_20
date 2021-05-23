using homework_20.Models.Repositories.Intarfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models
{
    public class DataManager
    {
        public ITextField TextFields { get; set; }

        public IServiseItems ServiceItems { get; set; }

        public DataManager(ITextField textFieldRepositories, IServiseItems serviceItemsRepositories)
        {
            TextFields = textFieldRepositories;
            ServiceItems = serviceItemsRepositories;
        }
    }
}
