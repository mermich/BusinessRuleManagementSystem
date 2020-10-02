using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public class DecisionSet
    {
        public List<DecisionTable> DecisionTables { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
