using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using FireSharp;
using FireSharp.Interfaces;
using FireSharp.Config;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace Ongbook
{
    /// <summary>
    /// Define a classe de inicialização da api
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor da classe Startup
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }




        /// <summary>
        /// Obtém as configurações do projeto
        /// </summary>
        public IConfigurationRoot Configuration { get; }





        /// <summary>
        /// Método chamado em tempo de execução para adicionar serviços ao conteiner
        /// </summary>
        /// <param name="services">Coleção de serviços</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddCors();
            services.AddMvc();
            services.AddSwaggerGen(options => {

                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "Ongbook.xml");

                if(File.Exists(filePath))
                    options.IncludeXmlComments(filePath);

                options.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Api de dados Ongbook V1.0",
                    Description = "A Api de dados do ongbook permite realizar operações sobre os dados cadastrados no ongbook.org",

                });

                options.SwaggerDoc("v2", new Info
                {
                    Version = "v2",
                    Title = "Api de dados Ongbook V2.0",
                    Description = "A Api de dados do ongbook permite realizar operações sobre os dados cadastrados no ongbook.org",

                });
            });
            
        }




        /// <summary>
        /// Método chamado em tempo de execução para a configuração do pipeline de requisições
        /// </summary>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {


            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Api/Error");
            }

            //app.Use(async (context, next) =>
            //{
            //    await next();
            //    if (context.Response.StatusCode == 404)
            //    {
            //        context.Request.Path = "/Api";
            //        await next();
            //    }
            //});

            app.UseStaticFiles();

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=App}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUi(c =>
            {
                c.RoutePrefix = "docs";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de dados Ongbook v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "API de dados Ongbook v2");
            });
            
            
                       

            Firebase.Configure();
        }
    }
}
