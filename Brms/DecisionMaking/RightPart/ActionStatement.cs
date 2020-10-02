using Brms.DecisionMaking;
using Brms.DecisionMaking.RightPart.ResultValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Brms.DecisionMaking.RightPart
{
    public class ActionStatement<T>
        where T : class
    {
        public PropertyInfo Property { get; set; }
        public IResultValue ResultValue { get; set; }

        public ActionStatement() { }

        public ActionStatement(PropertyInfo property, IResultValue resultValue)
        {
            Property = property;
            ResultValue = resultValue;
        }

        public ActionStatement(string propertyName, IResultValue resultValue)
        {
            Property = typeof(T).GetProperty(propertyName);
            ResultValue = resultValue;
        }

        public T ExecuteStatement(T input)
        {
            var asINeedInstance = ResultValue as INeedInstance<T>;
            if (asINeedInstance != null)
                asINeedInstance.Instance = input;

            Property.SetValue(input, ResultValue.GetResult());
            return input;
        }
    }
}
