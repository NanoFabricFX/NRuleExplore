using System;
using System.Collections.Generic;
using System.Reflection;
using NRuleExplore.Rules;
using NRules;
using NRules.Fluent;

namespace NRuleExplore
{
    class Program
    {
        static void Main(string[] args)
        {
            var rulesRepo = new RuleRepository();
            rulesRepo.Load(x => x.From(Assembly.GetExecutingAssembly()));

            var factory = rulesRepo.Compile();
            var session = factory.CreateSession();

            var orderItems = new List<OrderItem> {
                new OrderItem("A",5),
                new OrderItem("B", 2),
                new OrderItem("C",1),
                new OrderItem("D",1)
            };

            var order = new Orders(orderItems);

            session.Insert(order);
            session.Fire();

            Console.WriteLine($"Calculated order price is: {order.OrderPrice}");

            Console.ReadLine();
        }
    }
}
