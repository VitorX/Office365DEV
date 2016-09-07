using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADALSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            //CertHelperTest.CreateClientAssertion();
            //Console.WriteLine(TokenHelperTest.GetAccessTokenByCert());

            //TokenHelperTest.GetDeligateUserToken();
            string accessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IlliUkFRUlljRV9tb3RXVkpLSHJ3TEJiZF85cyIsImtpZCI6IlliUkFRUlljRV9tb3RXVkpLSHJ3TEJiZF85cyJ9.eyJhdWQiOiJodHRwczovL291dGxvb2sub2ZmaWNlLmNvbS8iLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC8wNDliZWY1Zi04ODQxLTQwMDAtOTg0Yi1jM2YzNmJkYjJkOGMvIiwiaWF0IjoxNDcyNjk1NzM1LCJuYmYiOjE0NzI2OTU3MzUsImV4cCI6MTQ3MjY5OTYzNSwiYWNyIjoiMSIsImFtciI6WyJwd2QiXSwiYXBwaWQiOiI1ZWZhOGFiYy0xM2RjLTQ2ODEtODNmNS1jNmZkZTA3MTE2YWMiLCJhcHBpZGFjciI6IjEiLCJmYW1pbHlfbmFtZSI6InRlY2giLCJnaXZlbl9uYW1lIjoic3AiLCJpcGFkZHIiOiIxNjcuMjIwLjI1NS40MyIsIm5hbWUiOiJzcCB0ZWNoIiwib2lkIjoiZTE1Y2YwOTgtYjkyYy00ODBkLWE3M2ItNzdmMmY1ZDMyYmZkIiwicHVpZCI6IjEwMDM3RkZFOEQ4QTE2NDUiLCJzY3AiOiJDYWxlbmRhcnMuUmVhZCBDYWxlbmRhcnMuUmVhZFdyaXRlLkFsbCBGaWxlcy5SZWFkIEZpbGVzLlJlYWQuQWxsIEZpbGVzLlJlYWRXcml0ZSBNYWlsLlJlYWRXcml0ZSBNYWlsLlJlYWRXcml0ZS5BbGwgTWFpbC5TZW5kIE1haWwuU2VuZC5BbGwgVXNlci5SZWFkIFVzZXIuUmVhZC5BbGwgVXNlci5SZWFkV3JpdGUiLCJzdWIiOiJSLTNXMnB5RHplWkNPdnlIMkFORG01Q3hTWUlHdVkzVjFYMkFOcGlfbEhJIiwidGlkIjoiMDQ5YmVmNWYtODg0MS00MDAwLTk4NGItYzNmMzZiZGIyZDhjIiwidW5pcXVlX25hbWUiOiJzcC50ZWNoQE8zNjVFM1cxNS5vbm1pY3Jvc29mdC5jb20iLCJ1cG4iOiJzcC50ZWNoQE8zNjVFM1cxNS5vbm1pY3Jvc29mdC5jb20iLCJ2ZXIiOiIxLjAifQ.vW9NOl5l6l3kIv33DcoTebBVqDH48iA-CM5RPlFfSo-2ooMNJauKLmAMuF9TUidBNiFySrcSX-mM4wVDEiCDwG3msgGRTmwweFhYpf8f-nDyIct3zcYTUI0gz9fqixlKfKU5VOW5-TPhIrPr07ZQoPoqRzXCZvHtJZMtDm_D15nPoNgaBkxw85-L9ac7ZQVaBsI6Fxgl0pCE3cK1wRtVxAx993o34lAA8XJg-0LBAvVpbiebmXZQz-UwsvaLjLlIdP494aohnNaA7uahNJBxs_N5BdSSpueEDsySHfZfs8KVTItCQcLV9NGEMA8r7suyZx87i0tdQd2Gv4d6joL6iQ";
            var token = new TokenHelper().Validate(accessToken);

            Console.ReadLine();



        }

      
    }
}
