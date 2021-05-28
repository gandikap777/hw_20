using homework_20.Models.Entity;
using homework_20.Models.Repositories.Intarfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Repositories.EntityFramework
{
    public class EFServiceItem : IServiseItems
    {
        private readonly ContextDb context;

        public EFServiceItem(ContextDb context) => this.context = context;

        void IServiseItems.DeleteServiceItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = id });
            context.SaveChanges();
        }

        ServiceItem IServiseItems.GetServiceItemById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }

        IQueryable<ServiceItem> IServiseItems.GetServiceItems()
        {

            return context.ServiceItems;
        }

        IQueryable<ServiceItem> IServiseItems.GetServiceItems(string type)
        {
            return context.ServiceItems.Where(x => x.ServiceType == type);
        }

        void IServiseItems.SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
