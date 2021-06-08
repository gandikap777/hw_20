using HomeWork_13.Models;
using HomeWork_13.Presenters;
using System;
using System.Collections.Generic;
using System.Windows;

namespace HomeWork_13
{
    /// <summary>
    /// Логика взаимодействия для PersonInfo.xaml
    /// </summary>
    public partial class PersonInfo : Window, IClientView
    {

        private Context_18 db;

        private ClientPresenter presenter;

        string selectedItemId;

        string selectedAccountId = null;

        private bool Result;

        string IClientView.SelectedItemId => selectedItemId;

        string IClientView.Tittle { set => this.Title = value; }

        string IClientView.SelectedAccountId => selectedAccountId;

        string IClientView.ComboBoxAccountId => (string)this.AccountComboBox.SelectedItem;

        string IClientView.AccountToId => this.AccountToBox.Text;

        bool IClientView.Capitalization => (bool)this.Capitalization.IsChecked;

        string IClientView.Dateopen => DateTime.Now.ToString();

        string IClientView.Period => (string)this.PeriodComboBox.SelectedItem;

        string IClientView.CountDeposit => this.CountDeposit.Text;

        bool IClientView.Result { set => this.Result = value; }

        string IClientView.Count => this.Count.Text;

        string IClientView.CountUp => this.CountUp.Text;

        string IClientView.Rate => (string)this.RateComboBox.SelectedItem;

        public PersonInfo(string selectedItemId)
        {
            this.selectedItemId = selectedItemId;

            InitializeComponent();          


            db = new Models.Context_18();

            presenter = new ClientPresenter(this);

            this.Loaded += delegate
            {
                presenter.Loaded(selectedItemId);
            };

            this.OpenAccount.Click += delegate
            {
                try
                {
                    presenter.CreateAccount();
                }                    
                catch(CustomException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };

            this.AccountsList.SelectionChanged += delegate
            {
                if (AccountsList.SelectedItem != null)
                    selectedAccountId = (AccountsList.SelectedItem as Account).ID.ToString();
                else
                    selectedAccountId = null;
            };

            this.OpenDeposit.Click += delegate
            {
                try
                {
                    presenter.CreateDeposit();
                    RateComboBox.SelectedItem = null;
                    AccountComboBox.SelectedItem = null;
                    Capitalization.IsChecked = false;
                    CountDeposit.Text = "";
                    PeriodComboBox.SelectedItem = PeriodComboBox.Items[0];
                }
                catch (CustomException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            };

            this.Transfer.Click += delegate
            {
                try
                {
                    presenter.Transfer();
                    AccountToBox.Text = "";
                    Count.Text = "";
                    MessageBox.Show("Успешно!");
                }
                catch (CustomException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            };

            this.TopUpBalance.Click += delegate
            {
                try
                {
                    presenter.TopUpBalance();
                    CountUp.Text = "";
                }
                catch (CustomException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            };

        }

        public void LoadAccounts(IEnumerable<Account> accounts)
        {
            AccountsList.ItemsSource = accounts;

        }

        public void LoadDeposits(IEnumerable<Deposit> deposits)
        {
            DepositsList.ItemsSource = deposits; ;
        }

        public void LoadMessages(IEnumerable<Messages> messages)
        {
            MessageList.ItemsSource = messages; ;
        }


        void IClientView.LoadRate(IEnumerable<string> rates)
        {
            RateComboBox.ItemsSource = rates;
        }

        void IClientView.LoadAccountsComboBox(IEnumerable<string> accounts)
        {
            AccountComboBox.ItemsSource = accounts;
        }

        void IClientView.LoadPeriod(IEnumerable<string> periods)
        {
            PeriodComboBox.ItemsSource = periods;
            PeriodComboBox.SelectedItem = "1";
        }
    }
}
