
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TestsCreator.MethodGeneration;

namespace TestsCreator.ClassGeneration
{
    public class ClassGenerator
    {
        public string FilePath { get; set; }

        public ClassGenerator() { }

        public static Document doc;

        public ClassGenerator(string filePath)
        {
            FilePath = filePath;
        }


        public void GenerateClass()
        {
            var lst = new List<IEnumerable<int>>();
            lst.Add(new List<int>());
            lst.Add(new LinkedList<int>());

            var filtree = lst.OfType<List<int>>();


            //read class from file path
            var code = new StreamReader(FilePath).ReadToEnd();
            SyntaxTree tree = SyntaxFactory.ParseSyntaxTree(code);


            var Mscorlib = MetadataReference.CreateFromFile(FilePath);
            var compilation = CSharpCompilation.Create("MyCompilation", syntaxTrees: new[] { tree }, references: new[] { Mscorlib });
            var model = compilation.GetSemanticModel(tree);


            var root = tree.GetRoot();
            // Get the first class from the syntax tree
            //loop over classes
            foreach (var item in root.DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                var methods = item.DescendantNodes().OfType<MethodDeclarationSyntax>();

                var workingMethods = methods.Select(a => new WorkingMethod(item, a, model));
                var generatedMethods = workingMethods.Select(w => w.GenerateTestMethods(false, false)).ToList();
            }


            //MSBuildWorkspace workspace = MSBuildWorkspace.Create();
            //Solution originalSolution = workspace.OpenSolutionAsync(@"C:\Users\emermillod\Documents\Visual Studio 2013\Projects\BusinessRuleManagementSystem\BusinessRuleManagementSystem.sln").Result;
            //Solution newSolution = originalSolution;

            //var projects = newSolution.Projects;
            ////var project =  newSolution.AddProject("testproj", "testprojAssemb", LanguageNames.CSharp);
            ////  workspace.TryApplyChanges(project.Solution);
            ////  newSolution.Projects.Count();

            //var consoleApplication1 = projects.FirstOrDefault(p => p.AssemblyName == "ConsoleApplication1");
            //var newDoc = consoleApplication1.AddDocument("testDoc", "someTextContent");
            //workspace.TryApplyChanges(newDoc.Project.Solution.Workspace.CurrentSolution);


          
        }
    }
}
