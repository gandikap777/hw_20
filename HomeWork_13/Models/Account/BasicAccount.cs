using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class BasicAccount : Account
    {

        public BasicAccount() { }

        public BasicAccount(int IdClient, double Summ = 0) : base(IdClient, Summ)
        {

        }
    }
}
