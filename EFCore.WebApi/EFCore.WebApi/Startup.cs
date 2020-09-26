using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EFCore.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static readonly ILoggerFactory MyLoggerFactory
    = LoggerFactory.Create(builder => { builder.AddConsole(); });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Referencia do contexto e string  de conexão
            services.AddDbContext<HeroiContext>(options => 
            {
                //Dessa eu estou recebendo options no construtor do heroiContext, então precisamos instanciar ele para ter acesso
                //Grava log dos execs do sql pelo linq na saida do console.
                options.UseLoggerFactory(MyLoggerFactory)
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            //Serviço(Interface) e Implementação
            //Dado a necessidade de alguem que implementou a interface, mande uma classe EFCoreRepositorio
            services.AddScoped<IEFCoreRepositorio, EFCoreRepositorio>();

            //Microsoft.AspNetCore.Mvc.NewtonsoftJson
            //Pra conseguir para o lopping infinito, para igonorar os loppings
            services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling =
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
