using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class NullClient : Person
    {
        public NullClient() : base("Undefined", "Undefined", DateTime.ParseExact("01.01.1900", "dd.MM.yyyy", null), DateTime.Now, 1) { }

    }

    public class NullAccount : Account
    {
        public NullAccount() : base(0, 0) { }

    }


    public class NullDeposit : Deposit
    {
        public NullDeposit() : base(DateTime.ParseExact("01.01.1900", "dd.MM.yyyy", null), 0, 0, false, 0, 0) { }

    }
}
