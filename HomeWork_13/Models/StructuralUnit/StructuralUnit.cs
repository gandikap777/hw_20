using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13
{
    public class StructuralUnit : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Идентификатор
        /// </summary>
        private int id;

        /// <summary>
        /// Наименование
        /// </summary>
        private string name;


        public StructuralUnit() { }

        public StructuralUnit(string Name)
        {
            this.name = Name;
        }

        /// <summary>
        /// Наименование подразделения
        /// </summary>
        virtual public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        virtual public int ID { get { return id; } set => id = value; }


        virtual public Person Manager { get; set; }


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
