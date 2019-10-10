using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogAlfaBravo.Aplication;
using BlogAlfaBravo.Dominio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace BlogAlfaBravo
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", 
                    new Info 
                    { 
                        Title = "API AlfaBravo", 
                        Version = "v1",
                        Contact = new Contact
                        {
                            Name = "AlfaBravo",
                            Url = "BlogAlfaBravo.com"
                        },
                        Description = "API para blogs."
                    });
                var path = Path.Combine(AppContext.BaseDirectory, "BlogAlfaBravo.xml");
                c.IncludeXmlComments(path);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUi(c =>
           {
               c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 docs");
           });
        }
    }
}
