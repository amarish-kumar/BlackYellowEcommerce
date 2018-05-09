using AutoMapper;
using BlackYellow.Authentication.Application;
using BlackYellow.Authentication.Application.Interfaces;
using BlackYellow.Authentication.Domain.Commands;
using BlackYellow.Authentication.Domain.Customers.Interfaces;
using BlackYellow.Authentication.Domain.Events;
using BlackYellow.Authetication.Data.Context;
using BlackYellow.Authetication.Data.EventSourcing;
using BlackYellow.Authetication.Data.Repository;
using BlackYellow.Authetication.Data.UoW;
using BlackYellow.Core.Domain.Bus;
using BlackYellow.Core.Domain.Events;
using BlackYellow.Core.Domain.Interfaces;
using BlackYellow.Core.Domain.Notifications;
using BlackYellow.Domain.EventHandlers;
using Equinox.Domain.CommandHandlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


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

            services.AddAutoMapper();

            // Adding MediatR for Domain Events and Notifications
            services.AddMediatR(typeof(Startup));


            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddScoped<IEventStore, SqlEventStore>();

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            // Domain - Commands
            services.AddScoped<INotificationHandler<RegisterNewCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<INotificationHandler<UpdateCustomerCommand>, CustomerCommandHandler>();
            services.AddScoped<INotificationHandler<RemoveCustomerCommand>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
           

            // Infra - Identity
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<CustomerEFContext>();
             

           

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
