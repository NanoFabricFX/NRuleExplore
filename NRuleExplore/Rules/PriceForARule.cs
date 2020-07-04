using System;
using NRules.Fluent.Dsl;

namespace NRuleExplore.Rules
{
    public class PriceForARule : Rule
    {
        public PriceForARule()
        {
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

            foreach (var item in orders.OrderItems)
            {
                var skuItem = orders.GetSku(item._skuId);

                if (item._skuId == "A")
                    item.TotalPrice = ((item._quantity - 3) * skuItem.Price) + 130;
            }
        }
    }
}
