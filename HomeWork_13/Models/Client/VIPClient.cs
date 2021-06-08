using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    class VIPClient : Person
    {

        public VIPClient() { }

        public VIPClient(string FirstName,
                        string LastName,
                        DateTime Birthday,
                        DateTime RegistrationDate,
                        int IdDept) : base(FirstName, LastName, Birthday, RegistrationDate, IdDept)
        {


        }

    }
}
