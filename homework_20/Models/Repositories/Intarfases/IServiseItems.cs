using homework_20.Models.Entity;
using System;
using System.Linq;

namespace homework_20.Models.Repositories.Intarfases
{
    public interface IServiseItems
    {

        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemById(Guid id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid id);
        IQueryable<ServiceItem> GetServiceItems(string type);

    }
}
