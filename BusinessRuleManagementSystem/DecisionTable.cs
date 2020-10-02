using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public class DecisionTable
    {
        public string Name { get; set; }

        protected List<Decision> decisions;
        public IReadOnlyCollection<Decision> Decisions { get { return decisions; } }


        public DecisionTable()
        {
            decisions = new List<Decision>();
        }
    }

    public class DecisionTable<T> : DecisionTable
        where T : class
    {
        public void AddDecision(Decision<T> decision)
        {
            if(decisions == null)
                decisions = new List<Decision>();

            decisions.Add(decision);
        }
    }
}
