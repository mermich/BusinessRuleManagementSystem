using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brms.DecisionMaking.LeftPart.TestOperand
{
    public interface IOperand : IValid
    {
        string OperandDisplay { get; set; }
        string OperandErrorMessage { get; set; }

        void Validate(object src, object toCompare);
    }


    public abstract class Operand : IOperand
    {
        private bool isValid;

        public string OperandDisplay { get; set; }
        public string OperandErrorMessage { get; set; }


        public IEnumerable<ValidationError> GetValidationErrors()
        {
            var result = new List<ValidationError>();
            if (!isValid)
                result.Add(new ValidationError(OperandErrorMessage));

            return result;
        }

        public void Validate(object value, object toCompare)
        {
            if (value is IComparable)
            {
                isValid = CompareTo((IComparable)value, toCompare);
            }
            else
            {
                throw new ArgumentException();
            }
        }


        public abstract bool CompareTo(IComparable value, object toCompare);
    }
}
