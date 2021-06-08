using HomeWork_13;
using homework_20.Models.Repositories.Intarfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Repositories.EntityFramework
{
    public class EFDepartment : IEFDepartment
    {
        private readonly ContextDb context;

        public EFDepartment(ContextDb context) => this.context = context;


        void IEFDepartment.DeleteDepartment(int id)
        {
            throw new NotImplementedException();
        }


        StructuralUnit IEFDepartment.GetDepartmentById(int id)
        {
            return context.StructuralUnits.FirstOrDefault(x => x.ID == id);
        }

        IQueryable<StructuralUnit> IEFDepartment.GetDepartments()
        {
            return context.StructuralUnits;
        }

        void IEFDepartment.SaveDepartment(StructuralUnit entity)
        {
            if (entity.ID == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

