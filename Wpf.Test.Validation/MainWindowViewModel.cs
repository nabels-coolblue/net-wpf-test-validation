using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpf.Test.Domain;

namespace Wpf.Test.Validation
{
    public class MainWindowViewModel
    {
        public Person Person { get; set; }

        public MainWindowViewModel()
        {
            Person = new Person();
        }
    }
}
