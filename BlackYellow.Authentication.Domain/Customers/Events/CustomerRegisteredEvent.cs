using System;
using BlackYellow.Authentication.Domain.Addresses;
using BlackYellow.Authentication.Users;
using BlackYellow.Core.Domain.Events;

namespace BlackYellow.Authentication.Domain.Events
{
    public class CustomerRegisteredEvent : Event
    {
        public CustomerRegisteredEvent(Guid id, string firstName, string lastName, string cpf, string phone, DateTime birth, User user, Address address)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            Phone = phone;
            Birthday = birth;
            User = user;
            Address = address;
            AggregateId = id;
        }
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