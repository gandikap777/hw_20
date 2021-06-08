using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    interface IClientView
    {
        string SelectedItemId { get; }
        string Tittle { set; }
        string SelectedAccountId { get; }
        string ComboBoxAccountId { get; }
        string AccountToId { get; }
        bool Capitalization { get; }
        string Dateopen { get; }
        string Rate { get; }
        string Period { get; }
        string CountDeposit { get; }
        string Count { get; }
        string CountUp { get; }
        bool Result { set; }

        void LoadAccounts(IEnumerable<Account> accounts);

        void LoadDeposits(IEnumerable<Deposit> deposits);

        void LoadMessages(IEnumerable<Messages> messages);

        void LoadRate(IEnumerable<string> rates);

        void LoadAccountsComboBox(IEnumerable<string> accounts);

        void LoadPeriod(IEnumerable<string> periods);
    }
}
