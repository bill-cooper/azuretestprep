using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestAPIManagement
{
    public class RestCall
    {
        private readonly string _apiVersion;
        private string _endpoint;
        private HttpMethod _method;
        private readonly string _payload;
        public RestCall(string endpoint, HttpMethod method, string payload = null)
        {
            _endpoint = endpoint;
            _method = method;
            _payload = payload;
        }

        public RestCall SetParameter(string paramName, string paramValue)
        {
            _endpoint = _endpoint.Replace("{" + paramName + "}", paramValue);
            return this;
        }
        public HttpResponseMessage Execute()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://management.azure.com");
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var request = new HttpRequestMessage(_method, _endpoint))
                {
                    if(!string.IsNullOrEmpty(_payload))
                        request.Content = new StringContent(_payload, Encoding.UTF8, "application/json");
                    var response = client.SendAsync(request).Result;
                    return response;
                }
            }
        }
    }
}
