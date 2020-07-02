using System;
using NRules.Fluent.Dsl;

namespace NRuleExplore.Rules
{
    public class PriceForBRule : Rule
    {
        public PriceForBRule()
        {
        }

        public override void Define()
        {
            Orders orders = null;
            int total = 0;
            int price = 0;
            When()
                .Match<Orders>(() => orders, o => o.items.Exists(s => s._skuId == "B" && s._quantity < 3))
                .Let(() => price, () => 100);

            Then()
                .Do(_ => Console.WriteLine(price));
        }
    }
}
