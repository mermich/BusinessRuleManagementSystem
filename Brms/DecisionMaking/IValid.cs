using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brms.DecisionMaking
{
    public interface IValid
    {
        IEnumerable<ValidationError> GetValidationErrors();
    }
}
