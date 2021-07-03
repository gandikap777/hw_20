using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public interface IClient
    {
        int ID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        DateTime Birthday { get; set; }
        DateTime RegistrationDate { get; set; }
        int IdDepartment { get; set; }
        bool GoodCreditHistory { get; }

    }
}
