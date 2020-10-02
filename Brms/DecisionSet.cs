using Brms.DecisionMaking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brms
{
    public class DecisionSet
    {
        public void AddDecisionTable<T>(DecisionTable<T> table)
            where T : class
        {

        }

        private List<object> decisions = new List<object>();
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
