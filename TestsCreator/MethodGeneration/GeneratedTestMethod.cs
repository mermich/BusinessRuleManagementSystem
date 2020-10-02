using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Reflection;
using TestsCreator.MethodGeneration.MethodParam;

namespace TestsCreator.MethodGeneration
{
    public class GeneratedTestMethod
    {
        public string Name { get; set; }
        public string FullContent { get; set; }

        public void Generates(List<WorkingParameterInfo> parameters)
        {

        }
    }
}
