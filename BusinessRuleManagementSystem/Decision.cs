using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public abstract class Decision :IValid
    {
        public abstract IEnumerable<ValidError> GetValidationErrors();
        public abstract IReadOnlyCollection<TestStatement> Conditions { get; }
        public abstract IReadOnlyCollection<ActionStatement> Results { get; }
    }


    public class Decision<T> : Decision
        where T : class
    {
        public Decision()
        {
            conditions = new List<TestStatement<T>>();
            results = new List<ActionStatement<T>>();
        }

        public bool AreConditionsVerified(T input)
        {
            return conditions.All(c => c.IsStatementVerified(input));
        }

        public T Execute(T input)
        {
            if(AreConditionsVerified(input))
            {
               foreach (var item in results)
               {
                   input = item.ExecuteStatement(input);
               }
            }

            return input;
        }

        public override IEnumerable<ValidError> GetValidationErrors()
        {
            return Conditions.SelectMany(c => c.GetValidationErrors()).Union(results.SelectMany(r => r.GetValidationErrors()));
        }



        private List<TestStatement<T>> conditions;

        public override IReadOnlyCollection<TestStatement> Conditions
        {
            get { return conditions; }
        }

        private void AddCondition(TestStatement<T> condition)
        {
            conditions.Add(condition);
        }

        private List<ActionStatement<T>> results;

        public override IReadOnlyCollection<ActionStatement> Results
        {
            get { return results; }
        }

        private void AddResult(ActionStatement<T> result)
        {
            results.Add(result);
        }
    }
}
