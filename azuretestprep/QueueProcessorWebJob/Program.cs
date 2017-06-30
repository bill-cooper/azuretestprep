using Microsoft.Azure.WebJobs;

namespace QueueProcessorWebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new JobHost();
            host.RunAndBlock();
        }
    }
}
