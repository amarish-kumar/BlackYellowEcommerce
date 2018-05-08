using System;
using BlackYellow.Authentication.Domain.Addresses;
using BlackYellow.Authentication.Users;
using BlackYellow.Core.Domain.Commands;

namespace BlackYellow.Authentication.Domain.Commands
{
    public abstract class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string Cpf { get; protected set; }

        public string Phone { get; protected set; }

        public User User { get; protected set; }

        public Address Address { get; protected set; }

        public DateTime Birthday { get; protected set; }
    }
}