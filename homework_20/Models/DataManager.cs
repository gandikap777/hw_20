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

        public IEFAccount Accounts { get; set; }

        public IEFClient Clients { get; set; }

        public IEFDeposit Deposits { get; set; }

        public DataManager(ITextField textFieldRepositories,
                           IServiseItems serviceItemsRepositories, 
                           IEFAccount accountsRepositories, 
                           IEFClient clientsRepositories, 
                           IEFDeposit depositsRepositories)
        {
            TextFields = textFieldRepositories;
            ServiceItems = serviceItemsRepositories;
            Accounts = accountsRepositories;
            Clients = clientsRepositories;
            Deposits = depositsRepositories;
        }
    }
}
