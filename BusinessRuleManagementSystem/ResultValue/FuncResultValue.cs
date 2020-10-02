using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public class FuncResultValue<T> : IResultValue<T>
    {
        public Func<T,Object> Method { get; set; }

        public Object GetResult(T input)
        {
            return Method(input);
        }

        public IEnumerable<ValidError> GetValidationErrors()
        {
            return new List<ValidError>();
        }
    }
}
