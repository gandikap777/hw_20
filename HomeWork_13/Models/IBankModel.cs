using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    interface IBankModel
    {
        IEnumerable<StructuralUnit> GetDepartments();

        IEnumerable<Person> GetClients(string selectedItemIdText);

    }
}
