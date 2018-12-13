using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Oracle.ManagedDataAccess.Client;
using Microsoft.EntityFrameworkCore;

using InfraBook.Context;

namespace InfraBook
{
    public class Startup
    {
        //CONSTRUCTOR
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }//END constructor

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // REMOVIDO O CONTEXTO DO ORACLE ATÉ QUE SE DECIDA O CONTRÁRIO, 13.12.2018
            var connectionString = this.Configuration["OracleDataBaseConnection:OracleDatabaseConnectionString"];
            services.AddDbContext<OracleContext>().BuildServiceProvider();

            var mySqlConnectionString = this.Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySqlContext>( options => {
                options.UseMySQL( mySqlConnectionString );
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


        }// END ConfigureServices()

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
