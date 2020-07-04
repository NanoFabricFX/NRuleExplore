using System;
namespace NRuleExplore.Domain
{
    public class Sku
    {
        public Sku(string id, int price)
        {
            Id = id;
            Price = price;
        }
        public string Id
        {
            get;
            private set;
        }
        public int Price
        {
            get;
            private set;
        }
    }
}
