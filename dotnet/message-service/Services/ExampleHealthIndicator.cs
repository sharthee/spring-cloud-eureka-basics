using System;
using Microsoft.Extensions.Logging;
using Steeltoe.Management.Endpoint.Health;

namespace MessageService.Services
{
    public class ExampleHealthIndicator : IHealthContributor
    {
        private readonly ILogger<ExampleHealthIndicator> _logger;
        public bool State { get; set; } = true;
        public ExampleHealthIndicator(ILogger<ExampleHealthIndicator> logger)
        {
            _logger = logger;
        }

        public Health Health()
        {
            _logger.LogInformation($"ExampleHealthIndicator called at {DateTime.Now} state={State}");
            var health = new Health();
            if (State)
            {
                health.Status = HealthStatus.UP;
            }
            else
            {
                health.Status = HealthStatus.DOWN;
                health.Details.Add("error","the sky is falling");
            }

            return health;
        }

        public string Id => "Example Health Indicator";
    }
}