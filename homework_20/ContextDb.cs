
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using homework_20.Models.Entity;
using System;

namespace homework_20.Models
{
    public class ContextDb : IdentityDbContext<IdentityUser>
    {
        public ContextDb(DbContextOptions<ContextDb> options) : base(options) { }

        public DbSet<ServiceItem> ServiceItems { get; set; }

        public DbSet<TextField> TextFileds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "1",
                Name = "admin",
                NormalizedName = "Administrator"

            });
            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "2",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@email.com",
                NormalizedEmail = "MY@EMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });

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
                Id = new Guid("4aa76a4c-c59d-409a-84c1-06e6487a137a"),
                CodeWord = "PageContacts",
                Tittle = "Контакты"
            });
        }
    }
}
