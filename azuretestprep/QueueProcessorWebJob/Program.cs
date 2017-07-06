using Microsoft.Azure.WebJobs;
using System.Diagnostics;

namespace QueueProcessorWebJob
{
    class Program
    {
        static void Main(string[] args)
        {

            var config = new JobHostConfiguration();
            config.Tracing.ConsoleLevel = TraceLevel.Verbose;
            
            config.UseTimers();
            config.UseDocumentDB();
            config.UseCore();

            using (var host = new JobHost(config))
            {
                host.RunAndBlock();
            }
        }
    }
}
