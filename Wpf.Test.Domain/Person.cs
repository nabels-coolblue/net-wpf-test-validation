using FluentValidation;
using Wpf.Test.Domain.Common;

namespace Coolblue.Domain
{
    public class Person : DomainObject
    {
        public Person(IValidator validator) : base(validator)
        {
        }

        public string FirstName { get; set; }
        public string SurName { get; set; }
    }
}
