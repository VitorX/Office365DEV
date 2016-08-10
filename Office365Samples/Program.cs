using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office365Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlliUkFRUlljRV9tb3RXVkpLSHJ3TEJiZF85cyIsImtpZCI6IlliUkFRUlljRV9tb3RXVkpLSHJ3TEJiZF85cyJ9.eyJhdWQiOiJodHRwczovL291dGxvb2sub2ZmaWNlLmNvbS8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC8wNDliZWY1Zi04ODQxLTQwMDAtOTg0Yi1jM2YzNmJkYjJkOGMvIiwiaWF0IjoxNDcwNzA4MzMxLCJuYmYiOjE0NzA3MDgzMzEsImV4cCI6MTQ3MDcxMjIzMSwiYWNyIjoiMSIsImFtciI6WyJwd2QiXSwiYXBwaWQiOiI1ZWZhOGFiYy0xM2RjLTQ2ODEtODNmNS1jNmZkZTA3MTE2YWMiLCJhcHBpZGFjciI6IjEiLCJmYW1pbHlfbmFtZSI6InRlY2giLCJnaXZlbl9uYW1lIjoic3AiLCJpcGFkZHIiOiIxNjcuMjIwLjI1NS40MyIsIm5hbWUiOiJzcCB0ZWNoIiwib2lkIjoiZTE1Y2YwOTgtYjkyYy00ODBkLWE3M2ItNzdmMmY1ZDMyYmZkIiwicHVpZCI6IjEwMDM3RkZFOEQ4QTE2NDUiLCJzY3AiOiJDYWxlbmRhcnMuUmVhZFdyaXRlIERpcmVjdG9yeS5SZWFkV3JpdGUuQWxsIE1haWwuUmVhZCBNYWlsLlJlYWQuQWxsIE1haWwuUmVhZFdyaXRlIE1haWwuU2VuZCIsInN1YiI6IlItM1cycHlEemVaQ092eUgyQU5EbTVDeFNZSUd1WTNWMVgyQU5waV9sSEkiLCJ0aWQiOiIwNDliZWY1Zi04ODQxLTQwMDAtOTg0Yi1jM2YzNmJkYjJkOGMiLCJ1bmlxdWVfbmFtZSI6InNwLnRlY2hATzM2NUUzVzE1Lm9ubWljcm9zb2Z0LmNvbSIsInVwbiI6InNwLnRlY2hATzM2NUUzVzE1Lm9ubWljcm9zb2Z0LmNvbSIsInZlciI6IjEuMCJ9.Z6Zv2X53v4gprdrvRBzLKXe33pPS2uj4zFYl1fbOLj7VJuO6bKiBZNDoEOaL8P1sMJuxCzQLHT3R1A7w9Ohx_TNj34zoWoD8a2BBhcNSqlki3cO1nPG9IBSCUGpS9BYBBdJMozEfhmTbjXLtUHtYHBiiXw5iNVCrx3l00mO-8_ejA-WyXVsPD3VxVpDzIovi-bHlvsEjOXRsNjHSH_Ckxx155CACSLqbs9MWBn37eCgh3hvlMMrhXF6nuspwMU6zCjEgg8v6F8_llkIluVD17plySkyeXq6BAqjqtKJnFCvYuXPWU2jFS9f5q1aA7pAiBscmCvKh3G6cHjEtPFxzVw";
            //MailCase.GetMessages(accessToken);
            EventCase.UpdateEvent(accessToken);

            Func<string, string> test = new Func<string, string>(Hello);

            Func<string, string> test2 = Hello;
            Console.ReadLine();
        }

        static string Hello(string name)
        {
            return "Hello " + name;
        }
    }
}
