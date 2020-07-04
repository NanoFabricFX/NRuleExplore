using System;
using System.Linq;
using System.Reflection;

namespace SimpleRuleEngine
{
    public static class RuleEngineHelper
    {
        public static Assembly GetRuleAssembly(Type extendableType)
        {
            var targetype = AppDomain
                                .CurrentDomain
                                .GetAssemblies()
                                .ToList()
                                .SelectMany(x => x.GetTypes())
                                .Where(t => t.BaseType == extendableType)
                                .FirstOrDefault();
            var targetassembly = Assembly.GetAssembly(targetype);
            return targetassembly;
        }
    }
}
