using System;
using System.Collections.Generic;

namespace NRuleExplore
{
    public class Orders
    {
        public Orders()
        {
            items = new List<OrderItem>();
        }
        public List<OrderItem> items { get; private set; }
        
    }
}
