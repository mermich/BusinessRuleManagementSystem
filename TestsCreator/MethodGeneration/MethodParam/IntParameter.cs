using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace TestsCreator.MethodGeneration.MethodParam
{
    public class IntParameter : MethodParameter
    {
        public override KeyValuePair<string, string> DefaultDeclaration
        {
            get
            {
                return new KeyValuePair<string, string>("0", "var " + ParameterInfo.Identifier + " = 0;");
            }
        }

        public override List<KeyValuePair<string, string>> CommonDeclarations
        {
            get
            {
                return new List<KeyValuePair<string, string>>() {
                   new KeyValuePair<string, string>("Minus1",  "var " + ParameterInfo.Identifier + " = -1;"),
                   new KeyValuePair<string, string>("1", "var " + ParameterInfo.Identifier + "= 1;"),
                   new KeyValuePair<string, string>("MinValue", "var " + ParameterInfo.Identifier + " = System.Int32.MinValue;"),
                   new KeyValuePair<string, string>("MaxValue", "var " + ParameterInfo.Identifier + " = System.Int32.MaxValue;")
                };
            }
        }

        public override string AssotiatedType
        {
            get
            {
                return "System.Int32";
            }
        }
    }
}
