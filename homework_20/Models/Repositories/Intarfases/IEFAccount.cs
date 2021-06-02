using HomeWork_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Repositories.Intarfases
{
    public interface IEFAccount
    {
        IAccount GetAccountById(int id);
        void SaveAccount(IAccount entity);
        void DeleteAccount(int id);
        IQueryable<IAccount> GetAccounts(int idClient);
    }
}
