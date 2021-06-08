using HomeWork_15_Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    [Table("Persons")]
    abstract public class Person : INotifyPropertyChanged, Models.IClient
    {

        public event PropertyChangedEventHandler PropertyChanged;

        ///// <summary>
        ///// Номер клиента
        ///// </summary>
        private int id;

        /// <summary>
        /// Имя Клиента
        /// </summary>
        private string firstName;

        /// <summary>
        /// Поле "Фамилия"
        /// </summary>
        private string lastName;

        /// <summary>
        /// Дата рождения
        /// </summary>
        private DateTime birthday;


        private int idDepartment;

        /// <summary>
        /// Идентификатор департамента
        /// </summary>
        public int IdDepartment
        {
            get { return idDepartment; }
            set { idDepartment = value; }
        }


        /// <summary>
        /// Дата регистрации
        /// </summary>
        private DateTime registrationdate;



        /// <summary>
        /// Реализация интерфейса INotifyPropertyChanged
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Person() { }

        public Person(string FirstName,
                        string LastName,
                        DateTime Birthday,
                        DateTime RegistrationDate,
                        int IdDept)
        {            
            this.firstName = FirstName;
            this.lastName = LastName;
            this.registrationdate = RegistrationDate;
            this.birthday = Birthday;
            this.idDepartment = IdDept;
        }

        /// <summary>
        /// Возраст
        /// </summary>
        virtual public int Age
        {
            get
            {

                return CustomCalculation.CalculateCountOfYear(birthday, DateTime.Today);
                               
            }
        }


        /// <summary>
        /// Признак хорошей кредитной истории
        /// </summary>
        virtual public bool GoodCreditHistory
        {
            get
            {
                if (Experience >= 3) return true;

                return false;
            }
        }



        /// <summary>
        /// Дата рождения
        /// </summary>
        virtual public DateTime Birthday
        {
            get => this.birthday; 
            set
            {
                this.birthday = value;
                //OnPropertyChanged(nameof(Birthday));
            }
        }

        /// <summary>
        /// Имя
        /// </summary>
        virtual public string FirstName
        {
            get => this.firstName; 
            set
            {
                this.firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        virtual public string LastName
        {
            get =>this.lastName; 
            set
            {
                this.lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }


        virtual public int ID { get => this.id; set => this.id = value; }

        /// <summary>
        /// Дата регистрации
        /// </summary>
        virtual public DateTime RegistrationDate
        {
            get => this.registrationdate; 
            set
            {
                this.registrationdate = value;
                
            }
        }

        /// <summary>
        /// Стаж работы
        /// </summary>
        virtual public int Experience
        {
            get
            {
                return CustomCalculation.CalculateCountOfYear(registrationdate, DateTime.Today);

            }
        }

        /// <summary>
        /// Полное имя клиента
        /// </summary>
        virtual public string FullName
        {
            get => FirstName + " " + LastName; 
        }

        /// <summary>
        /// Выводит информацию  детально
        /// </summary>
        /// <returns></returns>
        virtual public string PrintDetail()
        {
            string TempStr = "\n";

            TempStr += $"Фамилия { LastName } Имя { FirstName }\n";

            TempStr += $"Возраст: {Age}\n";

            TempStr += $"Период сотрудничества: {Experience}";

            return TempStr;
        }

        /// <summary>
        /// Перегрузка ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
                       
            return $"Имя: {this.firstName} Фамилия: {this.lastName} Возраст: {Age}";
        }

        /// <summary>
        /// Общие ДС клиента
        /// </summary>
        private double allbalance;

        public double AllBalance
        {
            get { return allbalance; }
            set 
            {
                allbalance = value;
                OnPropertyChanged(nameof(AllBalance));
            }
        }

    }
}
