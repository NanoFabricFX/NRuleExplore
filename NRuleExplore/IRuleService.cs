using System;
using NRuleExplore.Domain;

namespace NRuleExplore
{
    public interface IRuleService
    {
        void RunRuleService(Orders orders);
    }
}
