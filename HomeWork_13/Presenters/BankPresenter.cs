using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork_13.Models;

namespace HomeWork_13.Presenters
{
    class BankPresenter
    {
        IBankView view = null;
        IBankModel model = null;

        public BankPresenter(IBankView bankView)
        {
            view = bankView;

            model = new BankModel();
            view.LoadDepartments(model.GetDepartments());

        }

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        public void LoadCliens()
        {
            view.LoadClients(model.GetClients(view.SelectedDepartmentId));
        }


    }
}
