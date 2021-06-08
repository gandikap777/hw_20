using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class BasicDeposit : Deposit
    {
        public BasicDeposit() { }

        public BasicDeposit(DateTime DateOpen,
                            int Period,
                            double Summ,
                            bool Capitalization,
                            int Rate,
                            int IdClient) 
               : base(DateOpen, 
                      Period, 
                      Summ, 
                      Capitalization, 
                      Rate, 
                      IdClient)
        {

        }
    }
}

