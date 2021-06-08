using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    class CompanyClient : Person
    {

        public CompanyClient() { }

        public CompanyClient(string FirstName,
                        string LastName,
                        DateTime Birthday,
                        DateTime RegistrationDate,
                        int IdDept) : base(FirstName, LastName, Birthday, RegistrationDate, IdDept)
        {
            
          
        }

    }
}
