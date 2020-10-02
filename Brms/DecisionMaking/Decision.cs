using Brms.DecisionMaking.LeftPart;
using Brms.DecisionMaking.RightPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brms.DecisionMaking
{
    public class Decision<T> : IValid
        where T : class
    {
        public List<TestStatement<T>> Conditions { get; set; } = new List<TestStatement<T>>();
        public List<ActionStatement<T>> Results { get; set; } = new List<ActionStatement<T>>();


        public Decision() { }

        public Decision(List<TestStatement<T>> conditions, List<ActionStatement<T>> results)
        {
            Conditions = conditions;
            Results = results;
        }


        public bool AreConditionsVerified(T input)
        {
            Conditions.ForEach(i => i.Validate(input));
            return !Conditions.Any(c => c.ValidationErrors.Any());
        }

        public T Execute(T input)
        {
            if (AreConditionsVerified(input))
            {
                foreach (var item in Results)
                {
                    input = item.ExecuteStatement(input);
                }
            }

            return input;
        }

        public IEnumerable<ValidationError> GetValidationErrors()
        {
            return Conditions.SelectMany(c => c.ValidationErrors);
        }
    }
}
