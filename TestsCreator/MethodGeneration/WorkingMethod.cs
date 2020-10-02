using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TestsCreator.MethodGeneration.MethodParam;

namespace TestsCreator.MethodGeneration
{
    public class WorkingMethod
    {
        public ClassDeclarationSyntax ClassInfo { get; set; }
        public MethodDeclarationSyntax MethodInfo { get; set; }
        public SemanticModel SemanticModel { get; set; }

        public WorkingMethod()
        {

        }

        public WorkingMethod(ClassDeclarationSyntax classInfo, MethodDeclarationSyntax methodInfo, SemanticModel model)
        {
            ClassInfo = classInfo;
            MethodInfo = methodInfo;
            SemanticModel = model;
        }

        public List<WorkingParameterInfo> GetWorkingParameterInfos()
        {
            var workingParameterInfos = new List<WorkingParameterInfo>();

            foreach (var item in MethodInfo.ParameterList.Parameters)
            {
                workingParameterInfos.Add(new WorkingParameterInfo(item, SemanticModel));
            }
            return workingParameterInfos;
        }

        private IEnumerable<IEnumerable<GeneratedMethodParameter>> getParamaterCombinations(bool includeParameterCombinations, bool includeCodeBranchCombinations)
        {
            var result = new List<List<GeneratedMethodParameter>>();

            var workingParameterInfos = GetWorkingParameterInfos();
            var methodParameters = workingParameterInfos.Select(w => w.GetMethodParameter()).ToList();


            foreach (var item in methodParameters)
            {
                //generate a default method call
                List<GeneratedMethodParameter> generatedParameter = new List<GeneratedMethodParameter>();
                generatedParameter.Add(new GeneratedMethodParameter { MethodDeclarationText = item.Symbol.Name + item.DefaultDeclaration.Key, MethodSyntax = item.DefaultDeclaration.Value, ParameterName = item.Symbol.Name });

                //then if combinations generates a combinations of parameters values
                if (includeParameterCombinations)
                {
                    generatedParameter.AddRange(item.CommonDeclarations.Select(c => new GeneratedMethodParameter { MethodDeclarationText = item.Symbol.Name + c.Key, MethodSyntax = c.Value, ParameterName = item.Symbol.Name }).ToList());
                }

                result.Add(generatedParameter);
            }

            //if code banch then read the model and add extra comibations if not in dico.
            if (includeCodeBranchCombinations)
            {
                throw new NotImplementedException();
            }

            return result.CartesianProduct().ToList();
        }

        public List<GeneratedTestMethod> GenerateTestMethods(bool includeParameterCombinations = false, bool includeCodeBranchCombinations = false)
        {
            var parametersCombi = getParamaterCombinations(includeParameterCombinations, includeCodeBranchCombinations);

            List<GeneratedTestMethod> result = new List<GeneratedTestMethod>();

            foreach (var item in parametersCombi)
            {
                var constructedName = MethodInfo.Identifier.ToString() + "_" + string.Join("_", item.Select(i => i.MethodDeclarationText));

                result.Add(new GeneratedTestMethod()
                {
                    Name = constructedName,
                    FullContent = generatesMethodContent(constructedName, ClassInfo.Identifier.ToString(), item.Select(i => i.MethodSyntax).ToList(), item.Select(i => i.ParameterName).ToList(), MethodInfo.Identifier.ToString())
                });
            }

            return result;
        }

        private string generatesMethodContent(string methodDeclaration, string classDeclaration, List<string> parameterDeclarations, List<string> parameterNames, string call)
        {
            var bld = new StringBuilder();
            bld.AppendLine("[TestMethod]");
            bld.AppendLine("public void " + methodDeclaration);
            bld.AppendLine("{");
            bld.AppendLine("var instance = new " + classDeclaration + "();");
            foreach (var item in parameterDeclarations)
            {
                bld.AppendLine(item);
            }
            bld.AppendLine("instance." + call + "(" + string.Join(", ", parameterNames) + ");");
            bld.AppendLine("}");

            return bld.ToString();
        }
    }
}
