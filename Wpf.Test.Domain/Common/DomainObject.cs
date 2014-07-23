using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Wpf.Test.Domain.Common
{
    public class DomainObject : INotifyPropertyChanged
    {
        protected DomainObject() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            ValidateProperty(propertyName, value);

            if (object.Equals(storage, value)) return false;

            storage = value;
            OnPropertyChanged(propertyName);

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

        protected void ValidateProperty(object value, [CallerMemberName] string propertyName = null)
        {
            ValidateProperty(propertyName, value);
        }

        protected virtual void ValidateProperty(string propertyName, object value)
        {
        }
    }
}
