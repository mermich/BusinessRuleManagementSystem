using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRuleManagementSystem.Test
{
    class Sample
    {
        public void test()
        {
            DecisionTable<Class1> table = new DecisionTable<Class1>();
            Decision<Class1> dec = new Decision<Class1>();
            var conditions = new List<TestStatement<Class1>>();
            //conditions.Add(new TestStatement<Class1>{ SourceProperty = new PropertyInfo(), TestOperand = new})


            var results = new List<ActionStatement<Class1>>();
        }
    }
}
