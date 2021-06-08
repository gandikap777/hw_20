using homework_20.Models.Repositories.Intarfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw_22_web_api.Data
{
    public class DataManager
    {
        public IEFAccount Accounts { get; set; }

        public IEFClient Clients { get; set; }

        public IEFDeposit Deposits { get; set; }

        public IEFDepartment Departments { get; set; }

        public DataManager(IEFAccount accountsRepositories,
                           IEFClient clientsRepositories,
                           IEFDepartment departmentsRepositories,
                           IEFDeposit depositsRepositories)
        {

            Accounts = accountsRepositories;
            Clients = clientsRepositories;
            Departments = departmentsRepositories;
            Deposits = depositsRepositories;
        }
    }
}
