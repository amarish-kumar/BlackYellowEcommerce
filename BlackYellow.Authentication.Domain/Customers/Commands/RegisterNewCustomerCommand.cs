using BlackYellow.Authentication.Domain.Addresses;
using BlackYellow.Authentication.Domain.Validations;
using BlackYellow.Authentication.Users;
using System;

namespace BlackYellow.Authentication.Domain.Commands
{
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand(string firstName, string lastName, string cpf, string phone, DateTime birth, User user, Address address)
        {
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
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}