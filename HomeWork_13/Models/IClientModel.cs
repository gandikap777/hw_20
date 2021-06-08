using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    interface IClientModel
    {
        bool CreateAccount();

        bool CreateDeposit();

        bool Transfer();

        bool TopUpBalance();


        void GetDataDeposit(string SelectedItemId, 
                            string SelectedAccountId, 
                            string Summ, 
                            bool Capitalization, 
                            string Rate, 
                            string DateOpen,
                            string Period);

        void GetDataAccount(string SlelctedItemId,
                            string Summ);

        void GetDataTransfer(string SelectedAccountId,
                            string AccountToId,
                            string Summ);

        void GetDataTopUpBalance(string SelectedAccountId,
                                 string Summ);

        IEnumerable<Account> GetAccounts(string SelectedItemId);

        IEnumerable<Deposit> GetDeposits(string SelectedItemId);

        IEnumerable<Messages> GetMessages(string SelectedItemId);


        string GetTittle(string SelectedItemId);

        IEnumerable<string> GetRate(string SelectedItemId);

        IEnumerable<string> GetAccountsComboBox(string SelectedItemId);

        IEnumerable<string> GetPeriod(string SelectedItemId);

    } 
}
