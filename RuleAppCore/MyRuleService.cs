using System;
using Microsoft.Extensions.Logging;
using RuleAppCore.Domain;
using SimpleRuleEngine;

namespace RuleAppCore
{
    public class MyRuleService : IRuleService
    {
        private readonly ILogger<MyRuleService> _logger;
        private readonly IRuleEngine _ruleEngine;

        public MyRuleService(ILogger<MyRuleService> logger, IRuleEngine ruleEngine)
        {
            _logger = logger;
            _ruleEngine = ruleEngine;
        }

        public int GenerateInvoice(Orders orders) => orders.OrderPrice;

        public void RunRuleService(Orders orders)
        {
            try
            {
                _ruleEngine.BootStrapEngine();
                _logger.LogInformation("Rule engine started successfully");

                _logger.LogInformation($"Actual total order value is {orders.OrderPrice}");

                _ruleEngine.StartEngine(s => s.Insert(orders));

                _logger.LogInformation($"Rules are run on Orders and new promotional price is {orders.OrderPrice}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }


    }
}
