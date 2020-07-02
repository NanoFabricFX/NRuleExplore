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
            int price = 0;
            When()
                .Match<Orders>(() => orders, o => o.items.Exists(s => s._skuId == "A" && s._quantity>3))
                .Let(()=>total, ()=>orders.items.FindAll(s => s._skuId == "A").Count)
                .Let(()=>price, ()=> 1200);

            Then()
                .Do(_=> Console.WriteLine(price));
        }
    }
}
