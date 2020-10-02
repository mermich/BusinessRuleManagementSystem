using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace TestsCreator.MethodGeneration.MethodParam
{
    public class MyClassParameter : MethodParameter
    {
        public override KeyValuePair<string, string> DefaultDeclaration
        {
            get
            {
                return new KeyValuePair<string, string>(DefaultDeclarationKey, "var " + ParameterInfo.Identifier + " = new " + AssotiatedType + "();");
            }
        }

        public override List<KeyValuePair<string, string>> CommonDeclarations
        {
            get
            {
                return new List<KeyValuePair<string, string>>()
                {
                };
            }
        }

        public override string AssotiatedType
        {
            get
            {
                return "ConsoleApplication1.ARandomClass";
            }
        }
    }
}
