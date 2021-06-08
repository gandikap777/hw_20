using HomeWork_13.Presenters;
using HomeWork_13.Views;
using System.Collections.Generic;
using System.Windows;

namespace HomeWork_13
{
    /// <summary>
    /// Логика взаимодействия для PersonChange.xaml
    /// </summary>
    public partial class PersonChange : Window, IAddClientView
    {
        AddClientPresenter presenter;

        public PersonChange()
        {
            InitializeComponent();

            presenter = new AddClientPresenter(this);

            acceptbtn.Click += delegate
            {
                try
                {
                    presenter.Result();
                }
                catch (CustomException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            };
        }

        string IAddClientView.FirstNameText
        {
            get { return FirstNameBox.Text; }
        }
        string IAddClientView.LastNameText
        {
            get { return LastNameBox.Text; }
        }
        string IAddClientView.BirthdayText
        {
            get { return BirthdayBox.Text; }
        }
        string IAddClientView.RegistrationDateText
        {
            get { return EmploymentDateBox.Text; }
        }
        string IAddClientView.IdDepartmentText
        {
            get { return ((ComboBoxPairs) DepartmentComboBox.SelectedItem)?._Value; }
        }

        bool IAddClientView.Result { set => this.DialogResult = value; }


        void IAddClientView.LoadDepartments(IEnumerable<ComboBoxPairs> depts)
        {
            DepartmentComboBox.ItemsSource = depts;

            DepartmentComboBox.DisplayMemberPath = "_Key";
            DepartmentComboBox.SelectedValuePath = "_Value";
        }
    }
}
