using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf.Test.Wpf
{
    public class ErrorsContainer<T>
    {
        private static readonly T[] noErrors = new T[0];
        private readonly Action<string> raiseErrorsChanged;
        private readonly Dictionary<string, List<T>> validationResults;

        public ErrorsContainer(Action<string> raiseErrorsChanged)
        {
            if (raiseErrorsChanged == null)
            {
                throw new ArgumentNullException("raiseErrorsChanged");
            }

            this.raiseErrorsChanged = raiseErrorsChanged;
            this.validationResults = new Dictionary<string, List<T>>();
        }

        public bool HasErrors
        {
            get
            {
                return this.validationResults.Count != 0;
            }
        }

        public IEnumerable<T> GetErrors(string propertyName)
        {
            var localPropertyName = propertyName ?? string.Empty;
            List<T> currentValidationResults = null;
            if (this.validationResults.TryGetValue(localPropertyName, out currentValidationResults))
            {
                return currentValidationResults;
            }
            else
            {
                return noErrors;
            }
        }

        public void SetErrors(string propertyName, IEnumerable<T> newValidationResults)
        {
            var localPropertyName = propertyName ?? string.Empty;
            var hasCurrentValidationResults = this.validationResults.ContainsKey(localPropertyName);
            var hasNewValidationResults = newValidationResults != null && newValidationResults.Count() > 0;

            if (hasCurrentValidationResults || hasNewValidationResults)
            {
                if (hasNewValidationResults)
                {
                    this.validationResults[localPropertyName] = new List<T>(newValidationResults);
                    this.raiseErrorsChanged(localPropertyName);
                }
                else
                {
                    this.validationResults.Remove(localPropertyName);
                    this.raiseErrorsChanged(localPropertyName);
                }
            }
        }
    }
}
