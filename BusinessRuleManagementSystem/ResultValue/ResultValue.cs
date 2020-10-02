using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public interface IResultValue<T>: IValid
    {
        Object GetResult(T input);
    }
}
