using Microsoft.Extensions.Configuration;
using Models;
using System.Collections.Generic;
using Prometheus;

namespace api.Services.PrometheusService
{
    public class PrometheusService : IPrometheusService
    {
        private static readonly Counter RequestCounter = Metrics.CreateCounter("prometheus_requests_total", "Total number of requests for Promdata.");
        private static readonly Gauge ActiveRequests = Metrics.CreateGauge("prometheus_active_requests", "Number of active requests for Promdata.");

        public IEnumerable<Prom> GetProms()
        {
            RequestCounter.Inc(); // Increment the counter each time the method is called
            ActiveRequests.Inc(); // Increment the guage to indicate an active request

            return new List<Prom>
            {
                new Prom{ Id = 1, Name = "Prometheus: Always Watching, Always Counting" },
                new Prom{ Id = 2, Name = "Prometheus: Keeping Metrics Hot" }
            };
        }
    }
}
