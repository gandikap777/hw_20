using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_13.Models
{
    public class Context_18 : DbContext
    {

        

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<StructuralUnit> Departments { get; set; }

        public DbSet<Messages> Messages { get; set; }

        public Context_18() : base("DbConnection")
        {
            
            Database.SetInitializer<Context_18>(new Migrations.DBInitializer());
        }

        /// <summary>
        /// Метод записывает сообщение по клиенту и сохраняет в БД
        /// </summary>
        /// <param name="idclient"></param>
        /// <param name="msg"></param>
        public void WriteMessage(int idclient, string msg)
        {
            Messages.Add(new Messages() { IdClient = idclient, MSG = msg });
            SaveChanges();
        }
    }

}
