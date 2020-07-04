using System;
using NRules;

namespace SimpleRuleEngine
{
    public interface IRuleEngine
    {
        void BootStrapEngine();
        void StartEngine(Action<ISession> bootstrapAction);
    }
}
