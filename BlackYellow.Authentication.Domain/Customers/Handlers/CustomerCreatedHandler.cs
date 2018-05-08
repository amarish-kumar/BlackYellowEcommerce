using BlackYellow.Authentication.Domain.Customers.Events;
using BlackYellow.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Authentication.Domain.Customers.Handlers
{
    public class CustomerCreatedHandler : IHandler<CustomerCreatedEvent>
    {
        private List<CustomerCreatedEvent> _notifications;

        public void Dispose()
        {
            _notifications = new List<CustomerCreatedEvent>();
        }

        public List<CustomerCreatedEvent> GetValues()
        {
            return _notifications;
        }

        public void Handle(CustomerCreatedEvent args)
        {
            //TODO Send e-mail
        }

        public bool HasNotifications()
        {
            return GetValues().Count > 0;
        }

        public IEnumerable<CustomerCreatedEvent> Notify()
        {
            return GetValues();
        }
    }
}
