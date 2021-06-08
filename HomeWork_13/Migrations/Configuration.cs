namespace HomeWork_13.Migrations
{
    using HomeWork_13.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Context_18>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "HomeWork_13.Models.Context_18";
        }

        protected override void Seed(Context_18 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }

    public class DBInitializer : CreateDatabaseIfNotExists<Context_18>
    {
        /// <summary>
        /// Заполнение начальное таблиц
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(Context_18 context)
        {
            var departments = new List<StructuralUnit>
            {
                new StructuralUnit{Name = "Clients", ID = 1},
                new StructuralUnit{Name = "VIP Clients", ID = 2},
                new StructuralUnit{Name = "Company clients", ID = 3}
            };


            context.Departments.AddOrUpdate(x => new { x.Name, x.ID }, departments.ToArray()
                );
        }

    }

}
