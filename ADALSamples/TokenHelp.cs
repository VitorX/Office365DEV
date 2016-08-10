using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ADALSamples
{
    class TokenHelper
    {
        static string authority= "https://login.microsoftonline.com/common";
        public static async Task<string> GetTokenByCert(string clientId, string tenant, string certThumbprint,string resource)
        {
            string authority = $"https://login.windows.net/{tenant}";

            X509Certificate2 cert = CertHelper.FindCert(certThumbprint);
            var certCred = new ClientAssertionCertificate(clientId, cert);
            var authContext = new Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationContext(authority);
            AuthenticationResult result = null;
            try
            {
                result = await authContext.AcquireTokenAsync(resource, certCred);
            }
            catch (Exception ex)
            {
            }

            return result.AccessToken;
        }

        public static async Task<string> GetTokenAsync(string resource, string clientId, string secrect)
        {
            string authority = "https://login.microsoftonline.com/O365e3w15.onmicrosoft.com";
            AuthenticationContext authContext = new AuthenticationContext(authority);

            ClientCredential clientCredential = new ClientCredential(clientId, secrect);
            AuthenticationResult authResult=await authContext.AcquireTokenAsync(resource, clientCredential);
            return authResult.AccessToken;
        }
      
        public static string GetToken(string resource, string clientId, UserCredential userCredential)
        {
            AuthenticationContext authContext = new AuthenticationContext(authority);
            AuthenticationResult ar = authContext.AcquireTokenAsync(resource, clientId, userCredential).Result;
            return ar.AccessToken;
        }

        /// <summary>
        /// Version: 2.19.208020213
        /// </summary>
        /// <param name="resource"></param>
        /// <param name="clientId"></param>
        /// <param name="userCredential"></param>
        /// <returns></returns>
        public static string GetTokenOld(string resource, string clientId, UserCredential userCredential)
        {
            AuthenticationContext authContext = new AuthenticationContext(authority);
            //AuthenticationResult ar = authContext.AcquireToken(resource, clientId, userCredential);// old version
            PlatformParameters platformParameters = new PlatformParameters(PromptBehavior.Auto);
            AuthenticationResult ar = authContext.AcquireTokenAsync(resource, clientId, userCredential).Result;
            return ar.AccessToken;
        }

        public static string GetDeligateToken(string resource, string clientId,string redirectURL)
        {
            AuthenticationContext authContext = new AuthenticationContext(authority);
            AuthenticationResult authResult= authContext.AcquireTokenAsync(resource, clientId,new Uri(redirectURL), new PlatformParameters(PromptBehavior.Auto)).Result;
            return authResult.AccessToken;
        }
    }

  
}
