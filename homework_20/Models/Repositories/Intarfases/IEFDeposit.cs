using HomeWork_13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Repositories.Intarfases
{
    public interface IEFDeposit
    {
        IDeposit GetDepositById(int id);
        void SaveDeposit(IDeposit entity);
        void DeleteDeposit(int id);
        IQueryable<IDeposit> GetDeposits(int idClient);
    }
}
