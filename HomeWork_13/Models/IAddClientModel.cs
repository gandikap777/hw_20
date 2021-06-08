using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    interface IAddClientModel
    {
        bool Result();

        void GetData(string FirstName,
                     string LastName,
                     string Birthday,
                     string RegisrationDate,
                     string IdDepartment);

        IEnumerable<StructuralUnit> GetDepartments();
    }
}
