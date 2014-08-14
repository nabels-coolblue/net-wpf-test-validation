using FluentValidation;

namespace Coolblue.Domain
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
