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
            Console.WriteLine("Hello World!");

            var rulesRepo = new RuleRepository();
            rulesRepo.Load(x => x.From(Assembly.GetExecutingAssembly()));

            var factory = rulesRepo.Compile();
            var session = factory.CreateSession();

            var order = new Orders { items = { new OrderItem("A",5), new OrderItem("B", 2)} };

            session.Insert(order);
            session.Fire();

            Console.ReadLine();
        }
    }
}
