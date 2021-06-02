using HomeWork_13.Models;
using homework_20.Models.Repositories.Intarfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Repositories.EntityFramework
{
    public class EFAccount : IEFAccount
    {
        private readonly ContextDb context;

        public EFAccount(ContextDb context) => this.context = context;

        void IEFAccount.DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        IAccount IEFAccount.GetAccountById(int id)
        {
            return context.Accounts.FirstOrDefault(x => x.ID == id);
        }

        IQueryable<IAccount> IEFAccount.GetAccounts(int idClient)
        {
            return context.Accounts.Where(x => x.IdClient == idClient);
        }


        void IEFAccount.SaveAccount(IAccount entity)
        {
            if (entity.ID == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
