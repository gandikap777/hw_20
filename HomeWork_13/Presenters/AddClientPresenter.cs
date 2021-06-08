using HomeWork_13.Models;
using HomeWork_13.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Presenters
{
    class AddClientPresenter
    {
        IAddClientView view;
        IAddClientModel model;

        public AddClientPresenter(IAddClientView addclientView)
        {
            this.view = addclientView;

            model = new AddClientModel();

            LoadDepartments();
        }

        /// <summary>
        /// Добавление клиента
        /// </summary>
        public void Result()
        {
            model.GetData(view.FirstNameText, view.LastNameText, view.BirthdayText, view.RegistrationDateText, view.IdDepartmentText);
            view.Result = model.Result();
        }

        /// <summary>
        /// Получение списка департаментов
        /// </summary>
        public void LoadDepartments()
        {
            
            List<ComboBoxPairs> ComboBoxDep = new List<ComboBoxPairs>();

            foreach (StructuralUnit item in model.GetDepartments())
            {
                ComboBoxDep.Add(new ComboBoxPairs(item.Name, item.ID.ToString()));
            }

            view.LoadDepartments(ComboBoxDep);

        }
        
    }

    public class ComboBoxPairs
    {
        public string _Key { get; set; }
        public string _Value { get; set; }

        public ComboBoxPairs(string _key, string _value)
        {
            _Key = _key;
            _Value = _value;
        }
    }
}
