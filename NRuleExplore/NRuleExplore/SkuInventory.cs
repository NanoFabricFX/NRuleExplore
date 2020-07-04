﻿using System;
using System.Collections.Generic;

namespace NRuleExplore
{
    public class SkuInventory
    {
        public static IEnumerable<Sku> LoadSku()        
            => new List<Sku> {
                new Sku("A",50),
                new Sku("B",30),
                new Sku("C",20),
                new Sku("D",15)
            };
    }
}
