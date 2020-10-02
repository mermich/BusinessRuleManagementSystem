using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public interface ITestOperand : IValid
    {
        string OperandDisplay { get; set; }
        bool Compare(object src, object tocompare);
    }
}
