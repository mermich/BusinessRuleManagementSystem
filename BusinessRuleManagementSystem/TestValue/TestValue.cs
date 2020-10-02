using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public interface ITestValue : IValid
    {
    }

    public interface ITestValue<T> : ITestValue, IValid
        where T : class
    {
        Object GetValue(T input);
    }
}
