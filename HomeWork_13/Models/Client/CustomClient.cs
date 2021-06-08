using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    public class CustomClient : Person
    {

        public CustomClient() { }

        public CustomClient(string FirstName,
                        string LastName,
                        DateTime Birthday,
                        DateTime RegistrationDate,
                        int IdDept) : base(FirstName, LastName, Birthday, RegistrationDate, IdDept)
        {

        }

    }
}
