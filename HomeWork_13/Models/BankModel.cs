using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    class BankModel : IBankModel
    {
        
        private int SelectedItemId;
        /// <summary>
        /// Получение списка клиентов департамента
        /// </summary>
        /// <param name="selectedItemIdText"></param>
        /// <returns></returns>
        IEnumerable<Person> IBankModel.GetClients(string selectedItemIdText)
        {
            if (!Int32.TryParse(selectedItemIdText, out SelectedItemId)) throw new CustomException($"Неверно указан ИД департамента!", 10_109);

            Context_18 db = new Context_18();

            var clients = db.Persons.Where(x => x.IdDepartment == SelectedItemId).ToList();

            return clients;

        }

        /// <summary>
        /// Получение списка департаментов
        /// </summary>
        /// <returns></returns>
        IEnumerable<StructuralUnit> IBankModel.GetDepartments()
        {
            Context_18 db = new Context_18();

            var depts = db.Departments.ToList();

            db.Dispose();

            return depts;
        }
    }
}
