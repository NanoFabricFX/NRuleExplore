using System;
using System.Linq;
using System.Reflection;
using NRules;
using NRules.Fluent;
using NRules.Fluent.Dsl;

namespace SimpleRuleEngine
{
    public class RuleEngine : IRuleEngine
    {
        private ISession _session;
        public RuleEngine()
        {
        }

        public void BootStrapEngine()
        {
            var rulesRepo = new RuleRepository();

            Assembly targetassembly = RuleEngineHelper.GetRuleAssembly(typeof(Rule));

            rulesRepo.Load(x => x.From(targetassembly));

            var factory = rulesRepo.Compile();
            _session = factory.CreateSession();

            //add your custom invokers here

        }

        public void StartEngine(Action<ISession> bootstrapAction)  
        {
            bootstrapAction.Invoke(_session);
            _session.Fire();
        }
    }
}
