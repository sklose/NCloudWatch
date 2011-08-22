using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCloudWatch
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new CloudWatchService();
            service.Start();

            service.AddMetric(new PerformanceCounterMetric()
            {
                Name = "PagingFilePctUsage",
                Unit = MetricUnit.Percent,
                ReportInterval = TimeSpan.FromSeconds(60),
                PerformanceCounter = new PerformanceCounterDescription() 
                {
                    Category = "Paging File",
                    Name = "% Usage",
                    InstanceName = "_Total"
                }
            });

            service.SetAwsCredentials("XXX", "XXXX");

            Console.WriteLine("Press ANY KEY to exit ...");
            Console.ReadKey();

            IManagementService client = ManagementServiceClient.Create();
            foreach (var metric in client.GetMetrics())
            {
                Console.WriteLine(metric.Name);
            }

            service.Stop();
        }
    }
}