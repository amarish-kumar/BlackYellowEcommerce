using System;
using BlackYellow.Core.Domain.Events;

namespace BlackYellow.Authentication.Domain.Events
{
    public class CustomerRemovedEvent : Event
    {
        public CustomerRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}