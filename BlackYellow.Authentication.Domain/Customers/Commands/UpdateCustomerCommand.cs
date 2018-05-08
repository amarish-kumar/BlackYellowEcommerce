using System;
using BlackYellow.Authentication.Domain.Addresses;
using BlackYellow.Authentication.Domain.Validations;
using BlackYellow.Authentication.Users;
using FluentValidation.Results;

namespace BlackYellow.Authentication.Domain.Commands
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(Guid id, string firstName, string lastName, string cpf, string phone, DateTime birth, User user, Address address)
        {
            Id = Id;
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            Phone = phone;
            Birthday = birth;
            User = user;
            Address = address;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}