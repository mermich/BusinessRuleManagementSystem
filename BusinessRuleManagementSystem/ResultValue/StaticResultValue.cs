using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public class StaticResultValue<T> : IResultValue<T>
    {
        public Object Value { get; set; }

        public object GetResult(T input)
        {
            return Value;
        }

        public IEnumerable<ValidError> GetValidationErrors()
        {
            return new List<ValidError>();
        }
    }
}
