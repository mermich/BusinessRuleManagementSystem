using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace TestsCreator.MethodGeneration.MethodParam
{
    public class StringParameter : MethodParameter
    {
        public override KeyValuePair<string, string> DefaultDeclaration
        {
            get
            {
                return new KeyValuePair<string, string>("Empty", "var " + ParameterInfo.Identifier + " = Strimg.Empty;");
            }
        }

        public override List<KeyValuePair<string, string>> CommonDeclarations
        {
            get
            {
                return new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Null","var " + ParameterInfo.Identifier + " = null;"),
                    new KeyValuePair<string, string>("LoremIpsu","var " + ParameterInfo.Identifier + " = \"Lorem ipsu;\"")
                };
            }
        }

        public override string AssotiatedType
        {
            get
            {
                return "System.String";
            }
        }
    }
}
