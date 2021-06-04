
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using homework_20.Models.Entity;
using System;
using HomeWork_13;
using HomeWork_13.Models;
using homework_20.Service;

namespace homework_20.Models
{
    public class ContextDb : IdentityDbContext<User>
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }

        public DbSet<ServiceItem> ServiceItems { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<Person> Persons { get; set; }

        public DbSet<TextField> TextFileds { get; set; }

        public DbSet<StructuralUnit> StructuralUnits { get; set; }

        public DbSet<Messages> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BasicAccount>();
            builder.Entity<CustomClient>();
            builder.Entity<BasicDeposit>();
            builder.Entity<StructuralUnit>();

            builder.Entity<User>().HasIndex(x => x.Email).IsUnique();


            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "admin",
                NormalizedName = "Administrator"

            });
            builder.Entity<User>().HasData(new User
            {
                Id = "2",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

            ///add data
            ///
            builder.Entity<CustomClient>().HasData(new CustomClient() { ID = 1, FirstName = "Andrey", LastName = "Kolominov", Birthday = new DateTime(1989, 12, 4), RegistrationDate = new DateTime(2010, 11, 5), IdDepartment = 1 });

            builder.Entity<BasicAccount>().HasData(new BasicAccount() { ID = 1, Balance = 100, IdClient = 1});

            builder.Entity<BasicDeposit>().HasData(new BasicDeposit() { ID = 1, Summ = 1000, IdClient = 1, Capitalization = true, Period = 9, Rate = 7, DateOpen = new DateTime(2020, 10, 4) });

            builder.Entity<StructuralUnit>().HasData(new StructuralUnit() { ID = 1, Name = "Clients" });

            builder.Entity<StructuralUnit>().HasData(new StructuralUnit() { ID = 2, Name = "Vip Clients" });

            builder.Entity<StructuralUnit>().HasData(new StructuralUnit() { ID = 3, Name = "Company Clients" });
            
            //add service
            //builder.Entity<ServiceItem>().HasData(new ServiceItem
            //{
            //    Id = new Guid("1926c9bc-4da1-4063-8a61-918e9472a179"),
            //    Tittle = "First service",
            //    ServiceType = "МонтажныеРаботы",
            //    SubTittle = "Оказание монтажных работы по первой услуге"

            //});
            //builder.Entity<ServiceItem>().HasData(new ServiceItem
            //{
            //    Id = new Guid("a3e33d9a-e481-41f3-ae76-4608870821f8"),
            //    Tittle = "Second service",
            //    ServiceType = "ДемонтажныеРаботы",
            //    SubTittle = "Оказание услуг по демонтажу"

            //});
            //builder.Entity<ServiceItem>().HasData(new ServiceItem
            //{
            //    Id = new Guid("c9e722a5-5aa6-41e4-a159-b9474c8fd4b1"),
            //    Tittle = "Third service",
            //    ServiceType = "ПлиточныеРаботы",
            //    SubTittle = "Укладка плитки по третьей услге"

            //});

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "1",
                UserId = "2"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("63dc8fa6-07ae-4391-8916-e057f71239ce"),
                CodeWord = "PageIndex",
                Tittle = "Главная"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("70bf165a-700a-4156-91c0-e83fce0a277f"),
                CodeWord = "PageServices",
                Tittle = "Наши услуги"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("70bf155a-700a-4156-91c0-e83fce0a277f"),
                CodeWord = "PageDeposits",
                Tittle = "Вклады"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("70bf175a-700a-4156-91c0-e83fce0a277f"),
                CodeWord = "PageAccounts",
                Tittle = "Счета"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                CodeWord = "PageContacts",
                Tittle = "Контакты"
            });
        }
    }
}
