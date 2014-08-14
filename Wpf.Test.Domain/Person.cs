using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Internal;
using Wpf.Test.Domain.Common;

namespace Wpf.Test.Domain
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
