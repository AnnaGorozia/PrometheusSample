using Prometheus;
using Prometheus.DotNetRuntime;
using Prometheus.Experimental;

namespace PrometheusSample
{
    public static class MetricsBootstrap
    {
        public static void SetupServiceMetrics()
        {
            var registry = Metrics.DefaultRegistry;

            LocalTimeMetrics.Register(registry);

            DotNetRuntimeStatsBuilder.Customize()
                .WithGcStats(CaptureLevel.Verbose, Histogram.PowersOfTenDividedBuckets(-3, 1, 4))
                .WithContentionStats(CaptureLevel.Informational)
                .WithThreadPoolStats(CaptureLevel.Informational)
                .WithExceptionStats(CaptureLevel.Errors)
                .WithSocketStats()
                .StartCollecting(registry);
        }
    }
}
