using System;
using System.Collections.Generic;
using System.Linq;
using RuleAppCore.Domain.Helpers;

namespace RuleAppCore.Domain
{
    public class Orders
    {
        public Orders(IEnumerable<OrderItem> items)
        {
            OrderItems = new List<OrderItem>();
            OrderItems.AddRange(items);
            SkuInv = new List<Sku>();
            SkuInv.AddRange(SkuInventory.LoadSku());

            //foreach (var i in OrderItems)
            //{
            //    var sku_inv = GetSku(i._skuId);
            //    i.CalculateLinePrice(sku_inv.Price);
            //}


            OrderItems
                .ForEach(i => i.CalculateLinePrice(GetSku(i._skuId).Price));

            //CalculatePrice();
        }

        public List<OrderItem> OrderItems { get; private set; }

        public int OrderPrice {
            get => CalculatePrice(); 
            set { } }

        public List<Sku> SkuInv { get; }

        public int CalculatePrice() => 
            OrderItems.Select(i=>i.TotalPrice).Sum();


        public Sku GetSku(string Id) =>
                    SkuInv.Find(x => x.Id == Id) ?? throw new Exception("Item not present in Inventory");
        
    }
}
