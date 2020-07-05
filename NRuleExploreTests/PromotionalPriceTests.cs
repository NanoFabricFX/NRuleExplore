using System;
using System.Collections.Generic;
using AutoFixture;
using AutoFixture.AutoMoq;
using Microsoft.Extensions.Logging;
using Moq;
using NRules;
using RuleAppCore;
using RuleAppCore.Domain;
using SimpleRuleEngine;
using Xunit;

namespace NRuleExploreTests
{
    public class PromotionalPriceTests
    {
        [Fact]
        public void ShouldNot_RunRules_On_ScenarioA()
        {
            var ruleSvc = PromotionalPriceTests.CreateRuleService();

            var orderItems = new List<OrderItem> {
                    new OrderItem("A",1),
                    new OrderItem("B", 1),
                    new OrderItem("C",1),
                };
            var orders = new Orders(orderItems);

            ruleSvc.RunRuleService(orders);
            var promotionalPrice = ruleSvc.GenerateInvoice(orders);

            Assert.Equal(100, promotionalPrice);
        }

        [Fact]
        public void Should_RunRules_AandB_On_ScenarioB()
        {
            var ruleSvc = PromotionalPriceTests.CreateRuleService();

            var orderItems = new List<OrderItem> {
                    new OrderItem("A",5),
                    new OrderItem("B", 5),
                    new OrderItem("C",1),
                };
            var orders = new Orders(orderItems);

            ruleSvc.RunRuleService(orders);
            var promotionalPrice = ruleSvc.GenerateInvoice(orders);

            Assert.Equal(370, promotionalPrice);
        }

        [Fact]
        public void Should_RunRules_AandBandCD_On_ScenarioC()
        {
            var ruleSvc = PromotionalPriceTests.CreateRuleService();

            var orderItems = new List<OrderItem> {
                    new OrderItem("A",3),
                    new OrderItem("B", 5),
                    new OrderItem("C",1),
                    new OrderItem("D",1)
                };
            var orders = new Orders(orderItems);

            ruleSvc.RunRuleService(orders);
            var promotionalPrice = ruleSvc.GenerateInvoice(orders);

            Assert.Equal(280, promotionalPrice);
        }

        private static IRuleService CreateRuleService()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var loggerfacade = fixture.Freeze<Mock<ILogger<MyRuleService>>>();

            IRuleEngine ruleEngine = new RuleEngine();
            IRuleService ruleSvc = new MyRuleService(loggerfacade.Object, ruleEngine);
            return ruleSvc;
        }
    }
}
