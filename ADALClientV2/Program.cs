using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADALClientV2
{
    class Program
    {
        static void Main(string[] args)
        {
            GetToken();

            Console.ReadLine();
        }

        public static async void GetToken()
        {
            string clientId = "0cfa4d3e-db48-400f-9b44-901cd5975312";
            var app = new PublicClientApplication(clientId);
            AuthenticationResult result = null;
            try
            {
                string[] scopes = {
                        "https://outlook.office.com/mail.read",
                        "https://outlook.office.com/mail.readwrite",
                        "https://outlook.office.com/mail.send"
                    };

                result = await app.AcquireTokenAsync(scopes);
                Console.WriteLine(result.Token);
            }
            catch (MsalException ex)
            {

            }
        }
    }
}
