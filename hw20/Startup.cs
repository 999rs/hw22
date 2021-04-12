using DomainBasic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
            services.AddControllersWithViews();
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();   // добавляем механизм работы с сессиями


            //app.UseMiddleware<RouterMiddleware>();
            app.UseMiddleware<AuthenticationMiddleware>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });



        }

        public class AuthenticationMiddleware
        {
            private RequestDelegate _next;
            public AuthenticationMiddleware(RequestDelegate next)
            {
                _next = next;
            }
            public async Task InvokeAsync(HttpContext context)
            {
                if (!context.Session.Keys.Contains("Cart"))
                {

                    Cart cart = new Cart();
                    context.Session.Set<Cart>("Cart", cart);


                }
                await _next.Invoke(context);
                
            }
        }

        //public async void dddAsync(HttpContext context)
        //{
        //    await Task.Run(async () =>
        //    {

        //        await Task.Run(() =>
        //        {

        //            if (!context.Session.Keys.Contains("Cart"))
        //            {

        //                Cart cart = new Cart();
        //                context.Session.Set<Cart>("Cart", cart);


        //            }


        //        });
        //    });
        //}


        //public class RoutingMiddleware
        //{
        //    private readonly RequestDelegate _next;
        //    public RoutingMiddleware(RequestDelegate next)
        //    {
        //        _next = next;
        //    }

        //    public async Task InvokeAsync(HttpContext context)
        //    {



        //                if (!context.Session.Keys.Contains("Cart"))
        //                {

        //                    Cart cart = new Cart();
        //                    context.Session.Set<Cart>("Cart", cart);


        //                }
        //        await _next.Invoke(context);

        //        //await _next.Invoke(context);
        //    }
        //}

    }
}
