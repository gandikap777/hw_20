using HomeWork_13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Models.Repositories.Intarfases
{
    public interface IEFDepartment
    {
        StructuralUnit GetDepartmentById(int id);
        void SaveDepartment(StructuralUnit entity);
        void DeleteDepartment(int id);
        IQueryable<StructuralUnit> GetDepartments();
    }
}
