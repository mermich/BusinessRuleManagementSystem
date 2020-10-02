using Brms.DecisionMaking;
using Brms.DecisionMaking.LeftPart;
using Brms.DecisionMaking.LeftPart.TestOperand;
using Brms.DecisionMaking.RightPart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsCreator.ClassGeneration;
using Brms.DecisionMaking.RightPart.ResultValue;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBrms();

            // TestTestGenerator();
        }

        private static void TestBrms()
        {
            var instance = new ARandomClass();
            instance.ID = 8;


            var decision = new Decision<ARandomClass>();
            decision.Conditions.Add(new TestStatement<ARandomClass>("ID", new GreaterOrEqualsThanOperand(), 3));
            // decision.Results.Add(new ActionStatement<ARandomClass>("ID", new StaticResultValue(3)));
            decision.Results.Add(new ActionStatement<ARandomClass>("ID", new FuncResultValue<ARandomClass>(a => a.ID * a.ID, instance)));

            var result = decision.Execute(instance);
        }

        private static void TestTestGenerator()
        {
            string path = @"C:\Users\emermillod\Documents\Visual Studio 2013\Projects\BusinessRuleManagementSystem\ConsoleApplication1\ARandomClass.cs";
            ClassGenerator gen = new ClassGenerator(path);
            gen.GenerateClass();
        }
    }
}
