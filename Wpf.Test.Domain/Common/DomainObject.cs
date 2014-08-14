using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Coolblue.Domain.Common.Interfaces;
using FluentValidation;
using FluentValidation.Attributes;
using FluentValidation.Internal;
using FluentValidation.Results;

namespace Wpf.Test.Domain.Common
{
    public interface IDomainObject : IValidatable
    {
    }

    public abstract class DomainObject : IDomainObject
    {
        private readonly IValidator _validator;
        
        protected DomainObject(IValidator validator)
        {
            _validator = validator;
        }

        public bool IsValid
        {
            get { return Validate(new ValidationContext(this)).IsValid; }
        }

        public ValidationResult Validate(ValidationContext context)
        {
            return _validator.Validate(context);
        }
    }
}
