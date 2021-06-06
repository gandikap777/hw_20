using HomeWork_13;
using HomeWork_13.Models;
using homework_20.Models.Repositories.Intarfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Repositories.EntityFramework
{
    class EFClient : IEFClient
    {
        private readonly ContextDb context;

        public EFClient(ContextDb context) => this.context = context;

        void IEFClient.DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        IClient IEFClient.GetClientById(int id)
        {
            return context.Persons.FirstOrDefault(x => x.ID == id);
        }

        IQueryable<IClient> IEFClient.GetClients()
        {
            return context.Persons;
        }

        void IEFClient.SaveClient(IClient entity)
        {
            if (entity.ID == default)
            {
                context.Entry(entity).State = EntityState.Added;
                context.Persons.Add((Person)entity);         
            }

            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
