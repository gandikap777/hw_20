using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class AddClientModel : IAddClientModel
    {
        private string FirstNameText;
        private string LastNameText;
        private string BirthdayText;
        private string RegistrationDateText;
        private string IdDepartmentText;
        

        public AddClientModel()
        {
            
        }

        /// <summary>
        /// Получение данных модели для создания клиента
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Birthday"></param>
        /// <param name="RegisrationDate"></param>
        /// <param name="IdDepartment"></param>
        void IAddClientModel.GetData(string FirstName, string LastName, string Birthday, string RegisrationDate, string IdDepartment)
        {
            this.FirstNameText = FirstName;
            this.LastNameText = LastName;
            this.BirthdayText = Birthday;
            this.RegistrationDateText = RegisrationDate;
            this.IdDepartmentText = IdDepartment;
        }

        private string FirstName;
        private string LastName;
        private DateTime Birthday;
        private DateTime RegistrationDate;
        private int IdDepartment;
        private string TypeClient;

        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <returns></returns>
        bool IAddClientModel.Result()
        {
            Context_18 db = new Context_18();
            FirstName = this.FirstNameText;
            LastName = this.LastNameText;
            if (String.IsNullOrEmpty(this.BirthdayText)) { throw new CustomException($"Не корректно заполнен день рожения!", 18_109); }

            if (!DateTime.TryParse(this.BirthdayText, out Birthday)) { throw new CustomException($"Не корректно заполнен день рожения!", 18_109); }

            if (String.IsNullOrEmpty(this.IdDepartmentText)) { throw new CustomException($"Не указан департамент!", 19_109); }

            if (!Int32.TryParse(this.IdDepartmentText, out IdDepartment)) { throw new CustomException($"Не корректно указан департамент!", 19_109); }


            if (!String.IsNullOrEmpty(this.RegistrationDateText) && !DateTime.TryParse(this.RegistrationDateText, out RegistrationDate))
            {
                throw new CustomException($"Не корректно заполнена датарегистрации!", 18_109);
            }
            else RegistrationDate = DateTime.Now;

                if (IdDepartment == 2)
                TypeClient = "VIPClient";
            else if (IdDepartment == 3)
                TypeClient = "CompanyClient";
            else
                TypeClient = "Client";

            IClient client = ClientFactory.GetClient(TypeClient, FirstName, LastName, Birthday, RegistrationDate, IdDepartment);

            db.Persons.Add((Person)client);

            db.SaveChanges();

            return true;
        }

        /// <summary>
        /// Получение списка департаментов
        /// </summary>
        /// <returns></returns>
        IEnumerable<StructuralUnit> IAddClientModel.GetDepartments()
        {
            Context_18 db = new Context_18();

            var depts = db.Departments.ToList();

            db.Dispose();

            return depts;


        }
    }
}
