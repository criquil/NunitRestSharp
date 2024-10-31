using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace NunitRestSharp.Helper
{
    public class OAuthHelper
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<string?> GetBearerTokenAsync(string tenantId, string clientId, string clientSecret, string scope, string resource, string username, string password)
        {
            var tokenEndpoint = $"https://login.microsoftonline.com/{tenantId}/oauth2/token/";
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("username", username));
            collection.Add(new("password", password));
            collection.Add(new("scope", scope));
            collection.Add(new("grant_type", "password"));
            collection.Add(new("client_id", clientId));
            collection.Add(new("resource", resource));
            collection.Add(new("client_secret", clientSecret));
            var content = new FormUrlEncodedContent(collection);

            var response = await client.PostAsync(tokenEndpoint, content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var jsonResponse = JsonDocument.Parse(responseContent);

            if (jsonResponse.RootElement.TryGetProperty("access_token", out JsonElement accessTokenElement))
            {
                return accessTokenElement.GetString();
            }
            else
            {
                // Handle the case where the access_token is not present
                return null;
            }
        }
    }
}