using homework_20.Models;
using homework_20.Models.Repositories.EntityFramework;
using homework_20.Models.Repositories.Intarfases;
using homework_20.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20
{
    public class Startup
    {

        public IConfiguration Configeration { get; }
        public Startup(IConfiguration configuration) => Configeration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //Подключаем конфиг из appsettings.json
            Configeration.Bind("Project", new Config());

            //Подчключение сервисов
            services.AddTransient<ITextField, EFTextField>();
            services.AddTransient<IServiseItems, EFServiceItem>();
            services.AddTransient<DataManager>();



            //подключение контекста ДБ
            services.AddDbContext<ContextDb>(x => x.UseSqlServer(Config.ConnectionString));

            //
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ContextDb>().AddDefaultTokenProviders(); ;

            //настраиваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "CookieName";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //настраиваем политику авторизации для Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //Добавленяем поддержку контроллеров и представления (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAuthorization("Admin", "AdminArea"));
            })
                //Выставляем совместимость с asp.net core 3.0
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0);

            //logger
            services.AddSingleton(typeof(ILogger), services.BuildServiceProvider().GetService<ILogger<string>>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            
            app.UseRouting();

            //подключаем поддержку статических файлов
            app.UseStaticFiles();

            //подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();


            //ресгистрируем нужные нам маршруты (endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
