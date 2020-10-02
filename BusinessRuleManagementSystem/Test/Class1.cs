using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessRuleManagementSystem
{
    public class Class1
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Value { get; set; }

        public virtual List<Class2> Items { get; set; }
    }

    public class Class2
    {
        public int Color { get; set; }
    }
}
