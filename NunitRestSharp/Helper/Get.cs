using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitRestSharp.Helper
{
    internal class Get
    {
        public static RestResponse GetWithAuth(string url, string resource, string bearerToken)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource);
            request.AddHeader("Authorization", "Bearer " + bearerToken);
            var response =  client.Execute(request);
            return response;
        }
        public static RestResponse GetWithNoAuth(string url, string resource)
        {
            var client = new RestClient(url);
            var request = new RestRequest(resource);
            var response = client.Execute(request);
            return response;
        }
    }
}
