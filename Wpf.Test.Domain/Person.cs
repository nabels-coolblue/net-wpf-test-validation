using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Test.Domain.Common;

namespace Wpf.Test.Domain
{
    public class Person : DomainObject
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                SetProperty(ref _firstName, value);
                OnPropertyChanged(() => FullName);
            }
        }

        private string _surName;
        public string SurName
        {
            get
            {
                return _surName;
            }
            set
            {
                SetProperty(ref _surName, value);
                OnPropertyChanged(() => FullName);
            }
        }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, SurName);
            }
        }
    }
}
