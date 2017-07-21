using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIManagement
{
    class Program
    {
        static string SubscriptionId = "000000";
        static string ResourceGroupName = "group name";
        static void Main(string[] args)
        {

            var checkExists = new RestCall(
                "/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{parentResourcePath}/{resourceType}/{resourceName}?api-version={apiVersion}",
                HttpMethod.Head
                );
            var result = 
                checkExists.SetParameter("subscriptionId", SubscriptionId)
                        .SetParameter("resourceGroupName", ResourceGroupName)
                        .SetParameter("apiVersion", "api version")
                        .SetParameter("resourceProviderNamespace", "provider namespace")
                        .SetParameter("parentResourcePath", "resource path")
                        .SetParameter("resourceType", "resource type")
                        .SetParameter("resourceName", "resource name")
                        .Execute();
            
        }
    }
}
