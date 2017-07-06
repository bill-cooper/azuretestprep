using Microsoft.Azure.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueProcessorWebJob.Models
{
    public class Site
    {
        public string Url { get; set; }
        public SiteStatus Status { get; set; } = SiteStatus.New;
        public List<string> Images { get; set; }
    }

    public enum SiteStatus
    {
        New,
        Processing,
        Processed
    }
}
