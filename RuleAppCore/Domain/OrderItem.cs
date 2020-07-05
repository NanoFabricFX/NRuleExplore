using System;
using System.Collections.Generic;

namespace RuleAppCore.Domain
{
    public class OrderItem
    {
        public OrderItem(string skuId, int quantity)
        {
            _skuId = skuId;
            _quantity = quantity;
        }

        public string _skuId;
        public int _quantity;
        public int TotalPrice { get; set; }

        public void CalculateLinePrice(int itemPrice) => TotalPrice = _quantity * itemPrice;

    }
}
