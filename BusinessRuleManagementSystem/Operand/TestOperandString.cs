using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public class TestOperandEquals : ITestOperand
    {
        public string OperandDisplay
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<ValidError> GetValidationErrors()
        {
            return new List<ValidError>();
        }

        public bool Compare(object src, object tocompare)
        {
            throw new NotImplementedException();
        }
    }
}
