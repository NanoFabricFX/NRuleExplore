using System;
using RuleAppCore.Domain;

namespace RuleAppCore
{
    public interface IRuleService
    {
        void RunRuleService(Orders orders);
        int GenerateInvoice(Orders orders);
    }
}
