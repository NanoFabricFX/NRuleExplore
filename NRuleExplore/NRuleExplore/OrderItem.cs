﻿using System;
using System.Collections.Generic;

namespace NRuleExplore
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
    }
}
