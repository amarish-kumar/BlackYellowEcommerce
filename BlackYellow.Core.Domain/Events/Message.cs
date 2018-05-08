using System;
using MediatR;

namespace BlackYellow.Core.Domain.Events
{
    public abstract class Message : INotification
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}