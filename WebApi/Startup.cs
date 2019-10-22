using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore;
using Application.BusinessRules;
using Application.Entity;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "API AlfaBravo",
                        Version = "v1",
                        Contact = new Contact
                        {
                            Name = "AlfaBravo",
                            Url = "https://github.com/daniielamaro/APIAlfaBravo"
                        },
                        Description = "API para blogs."
                    });
                //var path = Path.Combine(AppContext.BaseDirectory, "WebApi.xml");
                //c.IncludeXmlComments(path);
            });

            ConfigMigration.Apply();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 docs");
                c.DocumentTitle = "API AlfaBravo";
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
