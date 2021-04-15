using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeNotas.Data;

[assembly: HostingStartup(typeof(SistemaDeNotas.Areas.Identity.IdentityHostingStartup))]
namespace SistemaDeNotas.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<SistemaDeNotasContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SistemaDeNotasContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SistemaDeNotasContext>();
            });
        }
    }
}