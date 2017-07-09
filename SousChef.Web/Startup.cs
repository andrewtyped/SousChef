using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SousChef.Data.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Swagger;

namespace SousChef.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            //using Configuration.GetConnectionString allows us to use the conn string in appsettings.Development.json, or the production conn string stored in Azure app settings
            services.AddDbContext<SousChefDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("SousChefDb")));
            services.AddMvc();

            services.AddSwaggerGen(cfg =>
            {
                cfg.SwaggerDoc("v1", new Info { Title = "Sous Chef API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddAzureWebAppDiagnostics();

            ConfigureAuth(app);
            ConfigureSwagger(app);

            app.UseMvc();           
        }

        public void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseJwtBearerAuthentication(new JwtBearerOptions
            {
                Authority = string.Format(Configuration["AzureAd:AadInstance"], Configuration["AzureAd:Tenant"], Configuration["AzureAd:SignUpSignInPolicyId"]),
                Audience = Configuration["AzureAd:ClientId"],
                Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = AuthenticationFailed
                }
            });
        }

        public void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(cfg =>
            {
                cfg.SwaggerEndpoint("/swagger/v1/swagger.json", "Sous Chef API V1");
            });
        }

        private Task AuthenticationFailed(AuthenticationFailedContext arg)
        {
            var s = $"AuthenticationFailed: {arg.Exception.Message}";
            arg.Response.ContentLength = s.Length;
            arg.Response.Body.Write(Encoding.UTF8.GetBytes(s), 0, s.Length);
            return Task.FromResult(0);
        }

    }
}
