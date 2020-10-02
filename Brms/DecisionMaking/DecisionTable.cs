using Brms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brms.DecisionMaking
{
    public class DecisionTable<T> where T : class
    {
        public string Name { get; set; }
        public List<Decision<T>> Decisions { get; set; } = new List<Decision<T>>();
    }
}
