using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public abstract class ActionStatement : IValid
    {
        public PropertyInfo ResultProperty { get; set; }

        public IEnumerable<ValidError> GetValidationErrors()
        {
            return new List<ValidError>();
        }
    }

    public class ActionStatement<T> : ActionStatement
        where T : class
    {
        public IResultValue<T> ResultValue { get; set; }

        public T ExecuteStatement(T input)
        {
            ResultProperty.SetValue(input, ResultValue.GetResult(input));
            return input;
        }
    }
}
