using System;
using hw20.Areas.Identity.Data;
using hw20.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(hw20.Areas.Identity.IdentityHostingStartup))]
namespace hw20.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SecContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SecContextConnection")));

                //services.AddIdentity<IdentityUser, IdentityRole>()
                //.AddEntityFrameworkStores<SecContext>()
                //.AddDefaultTokenProviders();


                services.AddDefaultIdentity<hw20User>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.SignIn.RequireConfirmedEmail = false;
                })
                    .AddEntityFrameworkStores<SecContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();
            });
        }
    }
}