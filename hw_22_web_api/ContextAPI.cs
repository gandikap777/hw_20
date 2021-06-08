using HomeWork_13;
using HomeWork_13.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw_22_web_api
{
    public class ContextAPI : DbContext
    {
        public ContextAPI(DbContextOptions<ContextAPI> options) : base(options) { }
               
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<StructuralUnit> StructuralUnits { get; set; }

        public DbSet<Messages> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BasicAccount>();
            builder.Entity<StructuralUnit>();
            builder.Entity<CustomClient>();
            builder.Entity<BasicDeposit>();

            base.OnModelCreating(builder);
        }
        
    }
}
