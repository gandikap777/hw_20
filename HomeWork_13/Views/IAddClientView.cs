using HomeWork_13.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Views
{
    interface IAddClientView
    {
        string FirstNameText { get; }
        string LastNameText { get; }
        string BirthdayText { get; }
        string RegistrationDateText { get; }
        string IdDepartmentText { get; }
        bool Result { set; }

        void LoadDepartments(IEnumerable<ComboBoxPairs> depts);
    }
}
