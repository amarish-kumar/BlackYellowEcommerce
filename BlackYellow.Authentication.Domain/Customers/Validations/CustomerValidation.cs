using System;
using BlackYellow.Authentication.Domain.Commands;
using FluentValidation;

namespace BlackYellow.Authentication.Domain.Validations
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Please ensure you have entered the Name")
                .Length(2, 150).WithMessage("The Name must have between 2 and 150 characters");
        }

        protected void ValidateBirthDate()
        {
            RuleFor(c => c.Birthday)
                .NotEmpty()
                .Must(HaveMinimumAge)
                .WithMessage("The customer must have 18 years or more");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.User.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateCpf()
        {
            RuleFor(c => c.Cpf)
                .NotEmpty()
                .Must(CpfIsValid)
                .WithMessage("The cpf is not valid");
            
        }

        protected static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }

        protected static bool CpfIsValid(string cpf)
        {
            return true;
        }
    }
}