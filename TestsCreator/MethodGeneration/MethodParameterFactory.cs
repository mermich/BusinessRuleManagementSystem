using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestsCreator.MethodGeneration.MethodParam;

namespace TestsCreator.MethodGeneration
{
    public class MethodParameterFactory
    {
        private List<MethodParameter> ExistingMethodParameter = new List<MethodParameter>() { new IntParameter(), /*new ARandomClassParameter(), */new StringParameter() };

        public MethodParameter GetMethodParameterFromType(string type)
        {
            return ExistingMethodParameter.FirstOrDefault(p => p.AssotiatedType.ToString() == type);
        }

        public MethodParameter GetMethodParameterFromType(Type type)
        {
            return GetMethodParameterFromType(type.ToString());
        }
    }
}
