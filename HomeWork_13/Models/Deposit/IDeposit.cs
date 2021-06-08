using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public interface IDeposit
    {
        int ID { get; set; }

        int IdClient { get; set; }

        double Summ { get; set; }

        DateTime DateOpen { get; set; }

        int Period { get; set; }

        bool Capitalization { get; set; }

        int Rate { get; set; }

        double Outcome { get;  }

        bool OpenDeposit();

        event Action<int, string> WriteMessage;

    }
}
