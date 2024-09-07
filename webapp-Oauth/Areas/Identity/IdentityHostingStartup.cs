using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using webapp_Oauth.Data;

[assembly: HostingStartup(typeof(webapp_Oauth.Areas.Identity.IdentityHostingStartup))]
namespace webapp_Oauth.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<webapp_OauthContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("webapp_OauthContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<webapp_OauthContext>();
            });
        }
    }
}
