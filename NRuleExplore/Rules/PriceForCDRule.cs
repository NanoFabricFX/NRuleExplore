using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using NRuleExplore.Domain;
using NRules.Fluent.Dsl;

namespace NRuleExplore.Rules
{
    public class PriceForCDRule : Rule
    {
        //ILogger<PriceForCDRule> _logger;
        public PriceForCDRule(/*ILogger<PriceForCDRule> logger*/)
        {
            //_logger = logger;
        }

        public override void Define()
        {
            Orders orders = null;

            When()
                .Match<Orders>(() => orders
                    , o => o.OrderItems.Any(i => i._skuId == "C")
                        && o.OrderItems.Any(i => i._skuId == "D"));

            Then()
                .Do(_ => ApplyPriceForRuleCD(orders));
        }

        private void ApplyPriceForRuleCD(Orders orders)
        {
            //_logger.LogInformation($"{this.GetType().Name} is applied");
            foreach (var item in orders.OrderItems)
            {
                if (item._skuId == "C") item.TotalPrice = 0;
                if (item._skuId == "D") item.TotalPrice = 30;
            }
        }
    }
}
