using Brms.DecisionMaking.LeftPart.TestOperand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Brms.DecisionMaking.LeftPart
{
    public class TestStatement<T> where T : class
    {
        public IOperand TestOperand { get; set; }
        public PropertyInfo Property { get; set; }

        public List<ValidationError> ValidationErrors { get; set; } = new List<ValidationError>();

        public object TestValue { get; set; }

        public TestStatement() { }

        public TestStatement(PropertyInfo propertyName, IOperand testOperand, object testValue)
        {
            Property = propertyName;
            TestOperand = testOperand;
            TestValue = testValue;
        }

        public TestStatement(string propertyName, IOperand testOperand, object testValue)
        {
            Property = typeof(T).GetProperty(propertyName);
            TestOperand = testOperand;
            TestValue = testValue;
        }

        public void Validate(T input)
        {
            var sourceValue = Property.GetValue(input);
            TestOperand.Validate(sourceValue, TestValue);

            ValidationErrors.Clear();
            ValidationErrors.AddRange(TestOperand.GetValidationErrors());
        }
    }
}
