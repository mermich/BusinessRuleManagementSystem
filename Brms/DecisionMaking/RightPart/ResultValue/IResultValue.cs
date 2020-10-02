using Brms.DecisionMaking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brms.DecisionMaking.RightPart.ResultValue
{
    public interface IResultValue
    {
        object GetResult();
    }

    public interface INeedInstance<T> where T :class
    {
        T Instance { get; set; }
    }
}
