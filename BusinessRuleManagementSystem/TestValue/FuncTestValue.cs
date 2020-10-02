using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public class FuncTestValue<T> : ITestValue<T>
         where T : class
    {
        public Func<T, object> Method { get; set; }

        public Object GetValue(T input)
        {
            return Method(input);
        }

        public IEnumerable<ValidError> GetValidationErrors()
        {
            return new List<ValidError>();
        }
    }
}
