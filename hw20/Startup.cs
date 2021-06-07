using DomainBasic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFRepository;
using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace hw20
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("DefaultConnection");

            //// установка конфигурации подключения
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //        .AddCookie(options => 
            //        {
            //            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Identity/Account/Login");
            //            options.LogoutPath = new Microsoft.AspNetCore.Http.PathString("/Identity/Account/LogOut");
            //            //options.
            //        });



            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings  
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.LoginPath = "/Identity/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login  
                options.LogoutPath = "/Identity/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout  
                options.AccessDeniedPath = "/Identity/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied  
                options.SlidingExpiration = true;
            });


            services.AddControllersWithViews();
            services.AddMvc();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();   // добавляем механизм работы с сессиями


            // добавляем мидлвейр инициации переменных сессии
            app.UseMiddleware<SessionVariablesMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


                
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("areas", "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            //using (var db = new SQLRepository())
            //{
            //    var folderPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "img", "Products");
            //    db.DownloadProdImages(folderPath);
            //}

            // загружаем картинку на диск
            var folderPath2 = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "img", "Products");
            DataApiCalls.Products.SaveImagesTo(folderPath2);


        }

        /// <summary>
        /// мидлвейр инициации переменных сессии
        /// </summary>
        public class SessionVariablesMiddleware
        {
            private RequestDelegate _next;
            public SessionVariablesMiddleware(RequestDelegate next)
            {
                _next = next;
            }
            public async Task InvokeAsync(HttpContext context)
            {
                // добавим пустую корзину если ее нет
                if (!context.Session.Keys.Contains("Cart"))
                {

                    Cart cart = new Cart();
                    context.Session.Set<Cart>("Cart", cart);

                }
                // идем по конвееру дальше
                await _next.Invoke(context);
                
            }
        }

    }
}
