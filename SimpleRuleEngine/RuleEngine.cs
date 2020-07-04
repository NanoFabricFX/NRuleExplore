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
        
        public RuleEngine(/*ILogger logger*/)
        {
        }

        public void BootStrapEngine()
        {
            var rulesRepo = new RuleRepository();

            try
            {

                Assembly targetassembly = RuleEngineHelper.GetRuleAssembly(typeof(Rule));

                rulesRepo.Load(x => x.From(targetassembly));

                var factory = rulesRepo.Compile();
                _session = factory.CreateSession();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void StartEngine(Action<ISession> bootstrapAction)  
        {
            //add your custom invokers here
            bootstrapAction.Invoke(_session);
            _session.Fire();
        }
    }
}
