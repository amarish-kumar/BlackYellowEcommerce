using BlackYellow.Authentication.Domain.Addresses;
using BlackYellow.Authentication.Domain.Validations;
using BlackYellow.Authentication.Users;
using System;

namespace BlackYellow.Authentication.Domain.Commands
{
    public class RegisterNewCustomerCommand : CustomerCommand
    {
        public RegisterNewCustomerCommand(string firstName, string lastName, string cpf, string phone, DateTime birth, string email, string password, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Cpf = cpf;
            Phone = phone;
            Birthday = birth;
            User = new User()
            {   
                Email = email,
                Password = password
            };
            
            Address = address;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCustomerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}