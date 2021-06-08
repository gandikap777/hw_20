using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public static class ClientFactory
    {
        /// <summary>
        /// Создание экземпляра клиента по типу
        /// </summary>
        /// <param name="TypeClient"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Birthday"></param>
        /// <param name="RegistrationDate"></param>
        /// <param name="IdDepartment"></param>
        /// <returns></returns>
        public static IClient GetClient (string TypeClient,
                                         string FirstName,
                                         string LastName,
                                         DateTime Birthday,
                                         DateTime RegistrationDate,
                                         int IdDepartment)
        {
            switch (TypeClient)
            {
                case "Client": return new CustomClient(FirstName, LastName, Birthday, RegistrationDate, IdDepartment);
                case "VIPClient": return new VIPClient(FirstName, LastName, Birthday, RegistrationDate, IdDepartment);
                case "CompanyClient": return new CompanyClient(FirstName, LastName, Birthday, RegistrationDate, IdDepartment);
                default: return new NullClient();
            }
        }
    }
}
