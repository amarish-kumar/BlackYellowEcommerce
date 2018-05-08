using BlackYellow.Authentication.Domain.Customers.Handlers;
using BlackYellow.Core.Domain.Events;
using BlackYellow.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Authentication.Application
{
   public class ApplicationService
    {
       // protected readonly IHandler<DomainNotification> Notifications;
        protected CustomerCreatedHandler CustomerCreatedHandler;

        public ApplicationService()
        {
           // this.Notifications = DomainEvent.Container.GetInstance<IHandler<DomainNotification>>();
           // this.CustomerCreatedHandler = DomainEvent.Container.GetInstance<CustomerCreatedHandler>();
        }
    }
}
