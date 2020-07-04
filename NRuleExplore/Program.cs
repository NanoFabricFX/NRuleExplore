using System;
using System.Collections.Generic;
using NRuleExplore.Domain;
using SimpleRuleEngine;

namespace NRuleExplore
{
    class Program
    {
        static void Main(string[] args)
        {
            var orderItems = new List<OrderItem> {
                new OrderItem("A",5),
                new OrderItem("B", 2),
                new OrderItem("C",1),
                new OrderItem("D",1)
            };
            var order = new Orders(orderItems);

            IRuleEngine ruleEngine = new RuleEngine();
            ruleEngine.BootStrapEngine();

            ruleEngine.StartEngine(s => s.Insert(order));

            Console.WriteLine($"Calculated order price is: {order.OrderPrice}");

            Console.ReadLine();
        }
    }
}
