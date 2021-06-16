using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public interface IAccount
    {
        int ID { get; set; }

        double Balance { get; set; }

        int IdClient { get; set; }

        event Action<int, string> WriteMessage;

        void IncreaseBalance(double Summ);

        void DecreaseBalance(double Summ);

    }
}
