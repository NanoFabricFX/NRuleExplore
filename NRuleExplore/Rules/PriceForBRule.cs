using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using NRuleExplore.Domain;
using NRules.Fluent.Dsl;

namespace NRuleExplore.Rules
{
    public class PriceForBRule : Rule
    {
        //private readonly ILogger<PriceForBRule> _logger;

        public PriceForBRule(/*ILogger<PriceForBRule> logger*/)
        {
            //_logger = logger;
        }

        public override void Define()
        {
            Orders orders = null;

            When()
                .Match<Orders>(() => orders, o => o.OrderItems.Exists(s => s._skuId == "B" && s._quantity >= 2));
                //.Let(() => total, () => orders.OrderItems.Where(i=>i._skuId=="B").FirstOrDefault()._quantity);

            Then()
                .Do(_ => ApplyPriceForRuleB(orders));
        }

        private void ApplyPriceForRuleB(Orders orders)
        {
            //_logger.LogInformation($"{this.GetType().Name} is applied");
            foreach (var item in orders.OrderItems)
            {
                var skuItem = orders.GetSku(item._skuId);

                if (item._skuId == "B")
                {
                    var total = item._quantity;
                    var offerPriceItems = total / 2;
                    var normalPriceItems = total % 2;
                    item.TotalPrice = (normalPriceItems * skuItem.Price) + (offerPriceItems * 45);
                }
            }
        }
    }
}
