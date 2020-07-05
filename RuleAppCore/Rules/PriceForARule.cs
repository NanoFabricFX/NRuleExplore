using System;
using Microsoft.Extensions.Logging;
using RuleAppCore.Domain;
using NRules.Fluent.Dsl;

namespace RuleAppCore.Rules
{
    public class PriceForARule : Rule
    {
        //private readonly ILogger<PriceForARule> _logger;

        public PriceForARule(/*ILogger<PriceForARule> logger*/)
        {
            //_logger = logger;
        }

        public override void Define()
        {
            Orders orders = null;
            int total = 0;

            When()
                .Match<Orders>(() => orders, o => o.OrderItems.Exists(s => s._skuId == "A" && s._quantity > 3))
                .Let(() => total, () => orders.OrderItems.FindAll(s => s._skuId == "A").Count);

            Then()
                .Do(_ => ApplyPriceForRuleA(orders));
        }

        private void ApplyPriceForRuleA(Orders orders)
        {
            //_logger.LogInformation($"{this.GetType().Name} is applied");

            foreach (var item in orders.OrderItems)
            {
                var skuItem = orders.GetSku(item._skuId);

                if (item._skuId == "A")
                    item.TotalPrice = ((item._quantity - 3) * skuItem.Price) + 130;
            }
        }
    }
}
