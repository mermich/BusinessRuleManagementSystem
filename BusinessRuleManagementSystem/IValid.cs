using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public interface IValid
    {
        IEnumerable<ValidError> GetValidationErrors();
    }
}
