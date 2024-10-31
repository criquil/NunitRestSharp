using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace NunitRestSharp.Helper
{
    internal class Initializer
    {
        public static async Task<string> Initialize()
        {

            var tenantId = Environment.GetEnvironmentVariable("TenantId") ?? "";  
            var clientId = Environment.GetEnvironmentVariable("ClientId") ?? "";
            var clientSecret = Environment.GetEnvironmentVariable("ClientSecret") ?? "";
            var resource = Environment.GetEnvironmentVariable("Resource") ?? "";
            var scope = Environment.GetEnvironmentVariable("Scope") ?? "";
            var password = Environment.GetEnvironmentVariable("Password") ?? "";
            var username = Environment.GetEnvironmentVariable("AppUsername") ?? "";

            if (string.IsNullOrEmpty(tenantId) || string.IsNullOrEmpty(clientId) || string.IsNullOrEmpty(clientSecret) ||
                string.IsNullOrEmpty(resource) || string.IsNullOrEmpty(scope) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
            {
                Console.WriteLine("One or more configuration values are missing.");
                return "No Token";
            }

            var oauthHelper = new OAuthHelper();
            var token = await oauthHelper.GetBearerTokenAsync(tenantId, clientId, clientSecret, scope, resource, username, password);
            if (token != null)
            {
                Console.WriteLine("Bearer Token: " + token);
                return token;
                
            }
            else
            {
                Console.WriteLine("Failed to retrieve Bearer Token.");
                return "No Token";
    
            }
            
        }
        public static string URL()
        {
            var url = Environment.GetEnvironmentVariable("BaseUrl") ?? "URL Not found";
            return url;
        }
    }
}
