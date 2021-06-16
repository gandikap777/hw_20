using HomeWork_13;
using HomeWork_13.Models;
using hw_22_web_api.Models.Repositories.Interfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw_22_web_api.Models.Repositories.EntityFramework
{
    public class EFApiRepository : IApiRepository
    {
        private ContextAPI context;

        public EFApiRepository(ContextAPI context)
        {
            this.context = context;
        }

        Account IApiRepository.GetAccount(int id)
        {
            return context.Accounts.Where(x => x.ID == id).FirstOrDefault();
        }

        IEnumerable<IClient> IApiRepository.GetDepartmentClient(int idDepartment)
        {
            return context.Persons.Where(x=> x.IdDepartment == idDepartment).ToList();
        }

        IEnumerable<StructuralUnit> IApiRepository.GetDepartments()
        {
            return context.StructuralUnits.ToList();
        }

        Deposit IApiRepository.GetDeposit(int id)
        {
            return context.Deposits.Where(x => x.ID == id).FirstOrDefault();
        }

        void IApiRepository.SaveAccount(IAccount entity)
        {
            if (entity.ID == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        void IApiRepository.SaveClient(IClient entity)
        {
            if (entity.ID == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        Person IApiRepository.GetClient(int id)
        {
            return context.Persons.Where(x => x.ID == id).FirstOrDefault();
        }

        void IApiRepository.SaveDeposit(IDeposit entity)
        {
            if (entity.ID == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        void IApiRepository.IncreaseBalance(IAccount acc, double summ)
        {
            acc.WriteMessage += context.WriteMessage;

            acc.IncreaseBalance(summ);

        }

        void IApiRepository.DecreaseBalance(IAccount acc, double summ)
        {
            acc.WriteMessage += context.WriteMessage;

            acc.DecreaseBalance(summ);
        }

        void IApiRepository.Transfer(IAccount accFrom, IAccount accTo, double summ)
        {
            accFrom.WriteMessage += context.WriteMessage;

            accTo.WriteMessage += context.WriteMessage;

            accFrom.DecreaseBalance(summ);

            accTo.IncreaseBalance(summ);

        }
    }
}
