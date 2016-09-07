using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADALSamples
{
    class TokenHelperTest
    {
        public static string GetAccessTokenByCert()
        {
            string clientId = "5efa8abc-13dc-4681-83f5-c6fde07116ac";
            string certThumbprint = "‎e7d4d855be6e6ce1e895405909e803339ca9f385";
            string tenant = "o365e3w15.onmicrosoft.com";
            string apiResourceId = "https://manage.office.com";
            ////string apiResourceId = "https://outlook.office.com";
            //string apiResourceId = "https://graph.microsoft.com";
            Task<string> accessToken = TokenHelper.GetTokenByCert(clientId, tenant, certThumbprint, apiResourceId);
            return accessToken.Result;
        }

        public static string GetAccessTokenByCert2()
        {
            string clientId = "eae75bf2-a987-48b3-ac87-0f2a1700adab";
            string certThumbprint = "‎e7d4d855be6e6ce1e895405909e803339ca9f385";
            string tenant = "o365e3w15.onmicrosoft.com";
            string apiResourceId = "https://manage.office.com";
            Task<string> accessToken = TokenHelper.GetTokenByCert(clientId, tenant, certThumbprint, apiResourceId);
            return accessToken.Result;
        }

        public static void GetAccessTokenByUserCredential()
        {
            //UserCredential uc = new UserCredential("sp.tech@o365e3w15.onmicrosoft.com", "Welcome!23");
            UserCredential uc = new UserCredential("sp.tech@o365e3w15.onmicrosoft.com");
            UserPasswordCredential userPasswordCredential=new UserPasswordCredential("sp.tech@o365e3w15.onmicrosoft.com", "Welcome!23");
            string accessToken = TokenHelper.GetToken("https://outlook.office.com", "491533c4-42ce-4be6-ae03-47413a298468", userPasswordCredential);
            Console.WriteLine($"Access Token:\r\n {accessToken}");
        }

        public static void GetAccessTokenByClientCredential()
        {
            string clientId = "5efa8abc-13dc-4681-83f5-c6fde07116ac";
            string secrect = "+ae67Jr3Pdl3F4JcCWOfnoURa9WTzRmzaBOySXeGdVY=";
            //string resrouce = "https://outlook.office.com";
            string resrouce = "https://graph.microsoft.com";
            string accessToken= TokenHelper.GetTokenAsync(resrouce, clientId, secrect).Result;
            Console.WriteLine($"Access Token: {accessToken}");

        }

        public static void GetAccessTokenByUserCredential2()
        {
            string clientId = "9537d08e-3912-47ce-9dd1-f31da48881a4";
            //UserPasswordCredential userPasswordCredential = new UserPasswordCredential("sp.tech@o365e3w15.onmicrosoft.com", "Welcome!23");
            //UserPasswordCredential userPasswordCredential = new UserPasswordCredential("nanyu@o365e3w15.onmicrosoft.com", "138122c@");
            UserPasswordCredential userPasswordCredential = new UserPasswordCredential("dennis@O365E3W15.onmicrosoft.com", "1qaz@WSX");
            string resrouce = "https://graph.microsoft.com";//"https://outlook.office.com"
            string accessToken = TokenHelper.GetToken(resrouce, clientId, userPasswordCredential);
            Console.WriteLine($"Access Token:\r\n {accessToken}");
        }

        public static void GetDeligateUserToken()
        {
            //string clientId = "8657d35b-e2ae-4e2f-aeea-bb302061c4c9";
            //string clientId = "9537d08e-3912-47ce-9dd1-f31da48881a4";
            string clientId = "ce1c938c-001c-4caf-b078-9092103e1d49";
            //string resource = "https://graph.microsoft.com";
            string resource = "https://outlook.office.com";
            string accessToken = TokenHelper.GetDeligateToken(resource, clientId, "http://localhost");
            Console.WriteLine($"Access Token:\r\n {accessToken}");
        }
     
    }
}
