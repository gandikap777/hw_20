using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace HomeWork_13.Models
{
    interface IBankView
    {
        string SelectedDepartmentId { get; }

        void LoadDepartments(IEnumerable<StructuralUnit> depts);

        void LoadClients(IEnumerable<Person> clients);

    }
}
