using HomeWork_13.Models;
using homework_20.Models.Repositories.Intarfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Repositories.EntityFramework
{
    public class EFDeposit : IEFDeposit
    {
        private readonly ContextDb context;

        public EFDeposit(ContextDb context) => this.context = context;

        void IEFDeposit.DeleteDeposit(int id)
        {
            throw new NotImplementedException();
        }

        IDeposit IEFDeposit.GetDepositById(int id)
        {
            return context.Deposits.FirstOrDefault(x => x.ID == id);
        }

        IQueryable<IDeposit> IEFDeposit.GetDeposits(int idClient)
        {
            return context.Deposits.Where(x => x.IdClient == idClient);
        }

        void IEFDeposit.SaveDeposit(IDeposit entity)
        {
            if (entity.ID == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
