using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestsCreator.Configuration
{
    public class GenerationConfiguration
    {
        public ITestFramework TestFramework { get; set; }

        public ProjectGenerationConfiguration ProjectConfig { get; set; }
        public ClassGenerationConfiguration ClassConfig{ get; set; }
        public MethodGenerationConfiguration MethodConfig { get; set; }
    }

    public interface ITestFramework
    {

    }
}
