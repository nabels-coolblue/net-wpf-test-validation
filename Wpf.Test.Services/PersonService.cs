using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;
using Wpf.Test.Domain;

namespace Wpf.Test.Services
{
    public class PersonService
    {
        public bool SavePerson(Person person)
        {
            var saveSucceeded = false;
            var personIsValid = person.IsValid;

            if (personIsValid)
            {
                Console.WriteLine("Person is valid, saving person..");
                saveSucceeded = true;
            }
                
            return saveSucceeded;
        }
    }
}
