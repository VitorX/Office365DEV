using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RESTRequsetHelper
{
    public class RESTRequsetHelper
    {
        public static async Task<string> GetAsync(string uri, string accessToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", $"{accessToken}");

            return await client.GetAsync(uri).ContinueWith<string>((response) =>
             {
                 return response.Result.Content.ReadAsStringAsync().Result;
             });
        }


        public static async Task<string> PostAsync(string uri, string jsonBody, string accessToken)
        {
            return await SendHttpRequest(HttpVerb.POST, uri, jsonBody, accessToken);
        }

        public static async Task<string> PutAsync(string uri, string jsonBody, string accessToken)
        {
            return await SendHttpRequest(HttpVerb.PUT, uri, jsonBody, accessToken);
        }

        private static async Task<string> SendHttpRequest(HttpVerb ver, string uri, string jsonBody, string accessToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", $"{accessToken}");
            var stringContent = new StringContent(jsonBody,Encoding.UTF8,"application/json");

            if (ver == HttpVerb.POST)
            {
                return await client.PostAsync(uri, stringContent).ContinueWith<string>((response) =>
               {
                   return response.Result.Content.ReadAsStringAsync().Result;
               });
            }
            else
            {
                return await client.PutAsync(uri, stringContent).ContinueWith<string>((response) =>
                {
                    return response.Result.Content.ReadAsStringAsync().Result;
                });
            }

        }

        public static async Task<string> SendHttpRequest(HttpVerb ver, string uri, StreamContent steamBody, string accessToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", $"{accessToken}");

            if (ver == HttpVerb.POST)
            {
                return await client.PostAsync(uri, steamBody).ContinueWith<string>((response) =>
                {
                    return response.Result.Content.ReadAsStringAsync().Result;
                });
            }
            else
            {
                return await client.PutAsync(uri, steamBody).ContinueWith<string>((response) =>
                {
                    return response.Result.Content.ReadAsStringAsync().Result;
                });
            }

        }
    }

    public enum HttpVerb
    {
        POST,
        PUT
    }
}
