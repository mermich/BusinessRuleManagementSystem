using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brms.DecisionMaking
{
    public class ValidationError
    {
        public string Message { get; set; }


        public ValidationError()
        {
        }

        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
