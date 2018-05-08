using System;
using BlackYellow.Core.Domain.Events;
using FluentValidation.Results;

namespace BlackYellow.Core.Domain.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}