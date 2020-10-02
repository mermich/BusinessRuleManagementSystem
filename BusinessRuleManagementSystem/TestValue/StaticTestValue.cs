using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public class StaticTestValue<T> : ITestValue<T>
         where T : class
    {
        public Object Value { get; set; }

        public Object GetValue(T input)
        {
            return Value;
        }

        public IEnumerable<ValidError> GetValidationErrors()
        {
            return new List<ValidError>();
        }
    }
}
