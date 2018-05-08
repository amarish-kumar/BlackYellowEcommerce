using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BlackYellow.Authentication.Application;
using BlackYellow.Authentication.Application.Interfaces;
using BlackYellow.Authentication.Domain.Customers;
using BlackYellow.Authentication.Domain.Customers.Events;
using BlackYellow.Authentication.Domain.Customers.Handlers;
using BlackYellow.Authentication.Domain.Customers.Interfaces;
using BlackYellow.Authetication.Data.Repository;
using BlackYellow.Core.Domain.Events;
using BlackYellow.Core.Domain.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BlackYellow.API
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
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            
          
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
