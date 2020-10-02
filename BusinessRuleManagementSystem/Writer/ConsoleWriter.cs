using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleManagementSystem.Writer
{
    class ConsoleWriter
    {
        public string WriteTableToString<T>(DecisionTable<T> table)
             where T : class
        {
            StringBuilder bld = new StringBuilder();

            foreach (var line in table.Decisions)
            {
                foreach (var condition in line.Conditions)
                {
                    bld.Append(condition.ToString());
                }
            }

            return bld.ToString();
        }
    }
}
