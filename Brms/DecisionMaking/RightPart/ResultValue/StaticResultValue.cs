using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brms.DecisionMaking.RightPart.ResultValue
{
    public class StaticResultValue : IResultValue
    {
        public object Value { get; set; }

        public StaticResultValue(object value)
        {
            Value = value;
        }



        public object GetResult()
        {
            return Value;
        }
    }
}
