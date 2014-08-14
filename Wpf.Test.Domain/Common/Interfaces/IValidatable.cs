using FluentValidation;
using FluentValidation.Results;

namespace Coolblue.Domain.Common.Interfaces
{
    public interface IValidatable
    {
        ValidationResult Validate(ValidationContext context);
    }
}
