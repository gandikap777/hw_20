using HomeWork_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Repositories.Intarfases
{
    public interface IEFClient
    {
        IClient GetClientById(int id);
        void SaveClient(IClient entity);
        void DeleteClient(int id);
        IQueryable<IClient> GetClients();

    }
}
