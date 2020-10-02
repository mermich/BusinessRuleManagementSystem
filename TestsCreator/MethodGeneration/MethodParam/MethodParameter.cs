using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace TestsCreator.MethodGeneration.MethodParam
{
    public abstract class MethodParameter
    {
        /// <summary>
        /// Initialization statement of the parameter.
        /// </summary>
        public abstract KeyValuePair<string, string> DefaultDeclaration { get; }

        /// <summary>
        /// Very common values to test.
        /// </summary>
        public abstract List<KeyValuePair<string, string>> CommonDeclarations { get; }

        protected ParameterSyntax ParameterInfo { get; set; }
        public IParameterSymbol Symbol { get; set; }

        public void Construct(ParameterSyntax parameterInfo, IParameterSymbol symbol)
        {
            ParameterInfo = parameterInfo;
            Symbol = symbol;
        }

        public abstract string AssotiatedType { get; }

        public const string DefaultDeclarationKey = "Default";
    }

    public class GeneratedMethodParameter
    {
        public string MethodSyntax { get; set; }
        public string MethodDeclarationText { get; set; }
        public string ParameterName { get; set; }
    }
}
