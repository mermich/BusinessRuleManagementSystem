using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brms.DecisionMaking.RightPart.ResultValue
{
    public class FuncResultValue<T> : IResultValue, INeedInstance<T>
        where T :class
    {
        public Func<T,object> Method { get; set; }
        public T Instance { get; set; }

        public object GetResult()
        {
            return Method(Instance);
        }

        public FuncResultValue(Func<T, object> method,T instance)
        {
            Method = method;
            Instance = instance;
        }
    }
}
