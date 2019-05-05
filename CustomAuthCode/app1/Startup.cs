using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace WebApp1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //Registering of identity server for web app1
            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;
                opt.DefaultAuthenticateScheme = IdentityServerAuthenticationDefaults.AuthenticationScheme;

            })
                .AddIdentityServerAuthentication(
                    opt =>
                    {
                        opt.Authority = "http://localhost:5000";
                        opt.RequireHttpsMetadata = false;
                        opt.ApiName = "app1.api";
                    });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
