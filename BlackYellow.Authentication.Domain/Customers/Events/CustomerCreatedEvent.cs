using BlackYellow.Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.Authentication.Domain.Customers.Events
{
    public class CustomerCreatedEvent : IDomainEvent
    {
        public int Versao { get; private set; }

        public DateTime DataOcorrencia { get; private set; }
        public Customer Customer { get; private  set; }

        public CustomerCreatedEvent(Customer customer, DateTime dateOccured)
        {
            Versao = 1;
            DataOcorrencia = dateOccured;
            Customer = customer;
            
        }

        public CustomerCreatedEvent(Customer customer) : this(customer, DateTime.Now){ }
    }
}
