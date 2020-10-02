using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TestsCreator.MethodGeneration.MethodParam;

namespace TestsCreator.MethodGeneration
{
    public class WorkingParameterInfo
    {
        public SemanticModel SemanticModel { get; set; }
        public ParameterSyntax ParameterInfo { get; set; }

        public WorkingParameterInfo()
        {
        }
        public WorkingParameterInfo(ParameterSyntax parameterInfo, SemanticModel semanticModel)
        {
            ParameterInfo = parameterInfo;
            SemanticModel = semanticModel;
        }

        public MethodParameter GetMethodParameter()
        {
            var symbol = SemanticModel.GetDeclaredSymbol(ParameterInfo);
            var symbolDisplayFormat = new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces);
            string fullyQualifiedName = symbol.Type.ToDisplayString(symbolDisplayFormat);

            //resolve IMethodParameter by type
            MethodParameterFactory fac = new MethodParameterFactory();

            var parameter = fac.GetMethodParameterFromType(fullyQualifiedName);
            parameter.Construct(ParameterInfo, symbol);
            return parameter;
        }
    }
}
