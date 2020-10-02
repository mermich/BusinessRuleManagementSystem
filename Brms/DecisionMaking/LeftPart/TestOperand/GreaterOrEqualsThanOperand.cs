using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brms.DecisionMaking.LeftPart.TestOperand
{
    public class GreaterOrEqualsThanOperand : Operand
    {
        public override bool CompareTo(IComparable value, object toCompare)
        {
            return value.CompareTo(toCompare) >= 0;
        }
    }
}
