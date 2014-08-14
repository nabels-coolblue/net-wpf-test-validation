using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Wpf.Test.Domain
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty()
                .WithMessage("First name is required.");

            RuleFor(user => user.SurName)
                .NotEmpty()
                .WithMessage("Surname is required.");
        }
    }
}
