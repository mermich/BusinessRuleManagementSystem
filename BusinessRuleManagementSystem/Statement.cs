using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BusinessRuleManagementSystem
{

    public abstract class TestStatement : IValid
    {
        public ITestOperand TestOperand { get; set; }
        public PropertyInfo SourceProperty { get; set; }
        
        public IEnumerable<ValidError> GetValidationErrors()
        {
            return new List<ValidError>();
        }
    }


    public class TestStatement<T> : TestStatement
        where T : class
    {
        public ITestValue<T> TestValue { get; set; }

        public bool IsStatementVerified(T input)
        {
            var propValue = SourceProperty.GetValue(input);
            var sourceValue = SourceProperty.GetValue(input);
            return TestOperand.Compare(sourceValue, TestValue.GetValue(input));
        }
    }
}
