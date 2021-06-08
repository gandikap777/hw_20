using HomeWork_13.Models;
using HomeWork_13.Presenters;
using System.Collections.Generic;
using System.Windows;

namespace HomeWork_13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IBankView
    {

        private Context_18 db;
        private BankPresenter presenter;

        private string selectedItemId;

        string IBankView.SelectedDepartmentId { get => selectedItemId; }

        public MainWindow()
        {
            InitializeComponent();

            presenter = new BankPresenter(this);

            this.Loaded += delegate
            {
                db = new Context_18();

                if (DepartmentsList.SelectedItem != null)
                {
                    selectedItemId = ((StructuralUnit)DepartmentsList.SelectedItem).ID.ToString();
                    presenter.LoadCliens();
                }
            };

            this.Closing += delegate
            {
                db.Dispose();
            };

            this.DepartmentsList.SelectedCellsChanged += delegate
            {
                if (DepartmentsList.SelectedItem != null)
                {
                    selectedItemId = ((StructuralUnit)DepartmentsList.SelectedItem).ID.ToString();
                    presenter.LoadCliens();
                }

            };

            this.Clientinfo.Click += delegate
            {
                if (ClientsList.SelectedItem == null)
                {
                    MessageBox.Show("Выберите клиента !");
                    return;
                }

                PersonInfo NPWindow = new PersonInfo(((Person)ClientsList.SelectedItem).ID.ToString());
                NPWindow.Show();
            };

            this.ClientAdd.Click += delegate
            {
                PersonChange NPWindow = new PersonChange();
                if (NPWindow.ShowDialog() == true)
                {
                    if (DepartmentsList.SelectedItem != null)
                    {
                        selectedItemId = ((StructuralUnit)DepartmentsList.SelectedItem).ID.ToString();
                        presenter.LoadCliens();
                    }
                }
            };

   
        }
                

        /// <summary>
        /// Выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click_Exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
                

        void IBankView.LoadDepartments(IEnumerable<StructuralUnit> depts)
        {
            DepartmentsList.ItemsSource = depts;
        }

        void IBankView.LoadClients(IEnumerable<Person> clients)
        {
            ClientsList.ItemsSource = clients;
        }
    }
}
