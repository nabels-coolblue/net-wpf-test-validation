using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using Wpf.Test.Domain.Common;

namespace Wpf.Test.Wpf
{
    public class ViewModel<T> : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        IValidator Validator { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);

            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void OnPropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            var propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            this.OnPropertyChanged(propertyName);
        }

        // End// BindableBase

        private ErrorsContainer<ValidationResult> errorsContainer;
        
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        
        public bool HasErrors
        {
            get { return this.ErrorsContainer.HasErrors; }
        }
        
        protected ErrorsContainer<ValidationResult> ErrorsContainer
        {
            get
            {
                if (this.errorsContainer == null)
                {
                    this.errorsContainer =
                        new ErrorsContainer<ValidationResult>(pn => this.RaiseErrorsChanged(pn));
                }

                return this.errorsContainer;
            }
        }
        
        public IEnumerable GetErrors(string propertyName)
        {
            return this.errorsContainer.GetErrors(propertyName);
        }
        
        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method supports event.")]
        protected void RaisePropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Justification = "Method supports event.")]
        protected void RaiseErrorsChanged(string propertyName)
        {
            this.OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
        }

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs e)
        {
            var handler = this.ErrorsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
