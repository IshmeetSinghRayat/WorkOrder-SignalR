using System;
using WorkOrderApplication.Areas.Identity.Data;
using WorkOrderApplication.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(WorkOrderApplication.Areas.Identity.IdentityHostingStartup))]
namespace WorkOrderApplication.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<IdentityLoginProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UsingIdentityContextConnection")));

                services.AddDefaultIdentity<IdentityLoginProjectUser>()
                                .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<IdentityLoginProjectContext>();
            });
        }
    }
}