using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ADALSamples
{
    class CertHelperTest
    {
        public static void LoadCerFromFileTest()
        {
            X509Certificate2 x509 = CertHelper.LoadCertFromFile(@"C:\users\v-fexue\desktop\mycompanyname.cer");
            Console.WriteLine($"ThumbPrint:{x509.Thumbprint}\r\nPublic key:{x509.PublicKey.Key.ToString()}");
        }

        public static void TestSign()
        {
            var message = "Hello";
            string certThumbprint = "‎e7d4d855be6e6ce1e895405909e803339ca9f385";
            var cert = CertHelper.FindCert(certThumbprint);
            var signature = CertHelper.SignWithCertificate(message, cert);

            var certWithPublicKey = CertHelper.LoadCertFromFile(@"C:\users\v-fexue\desktop\mycompanyname.cer");
            Console.WriteLine($"verify the signatrue:{CertHelper.Verify(message, signature, certWithPublicKey)}");
        }

        public static void TestClientAssertion()
        {
            var message = "eyJhbGciOiJSUzI1NiIsIng1dCI6IjU5VFlWYjV1Yk9Ib2xVQlpDZWdETTV5cDg0VSJ9.eyJhdWQiOiJodHRwczpcL1wvbG9naW4ud2luZG93cy5uZXRcL28zNjVlM3cxNS5vbm1pY3Jvc29mdC5jb21cL29hdXRoMlwvdG9rZW4iLCJleHAiOjE0NzAxMjMwMjAsImlzcyI6IjVlZmE4YWJjLTEzZGMtNDY4MS04M2Y1LWM2ZmRlMDcxMTZhYyIsImp0aSI6IjQ4Y2QwZGI1LWJjN2MtNDY0Yy1iMzY1LWQ3YjM3OGFmNjdjYiIsIm5iZiI6MTQ3MDEyMjQyMCwic3ViIjoiNWVmYThhYmMtMTNkYy00NjgxLTgzZjUtYzZmZGUwNzExNmFjIn0";
            var signature = "eqZkb7o6Ci_R5L2Ahi_lOm93dyGzModApP6f-FEoIJaBsctqsBrqMe_NpP-ElCDxoR1J0wc6ozr_V_r2z3CfEd2iMull7P0OWIKdQ2q9GOTHRtnByh5fms-9T_ik90KHqW-HaLMgAwQkpfnfZF_pj5eaGtn4aOH7J5EjlqOAWa7QI8CSJs4u_vxWOKTRDEupg0zjgXvdksxWjtRKb-lL2qClt32jIIe4u8f1yAyHeAyQQBC1sQs2Jl3S8EvBhBR_etW_BsNnEmD9n76aZ1H3O7nKk_yqxy6mlzcpo-JoGqFctkDFKKuzvETwHp6F5tEGFffDHJ9WB1aplZnLKeZHbw";
            string certThumbprint = "‎e7d4d855be6e6ce1e895405909e803339ca9f385";
            var cert = CertHelper.FindCert(certThumbprint);
            var byteSignature = CertHelper.SignWithCertificate(message, cert);

            var testSignature = Convert.ToBase64String(byteSignature);
            Console.WriteLine($"{CertHelper.ConvertToBase64Url(signature) == testSignature}\r\n\r\n{signature}\r\n\r\n{testSignature}");
        }

        public static void TestClientAssertion2()
        {
            var base64Message = "eyJhbGciOiJSUzI1NiIsIng1dCI6IjU5VFlWYjV1Yk9Ib2xVQlpDZWdETTV5cDg0VSJ9.eyJhdWQiOiJodHRwczpcL1wvbG9naW4ud2luZG93cy5uZXRcL28zNjVlM3cxNS5vbm1pY3Jvc29mdC5jb21cL29hdXRoMlwvdG9rZW4iLCJleHAiOjE0NzAxMjMwMjAsImlzcyI6IjVlZmE4YWJjLTEzZGMtNDY4MS04M2Y1LWM2ZmRlMDcxMTZhYyIsImp0aSI6IjQ4Y2QwZGI1LWJjN2MtNDY0Yy1iMzY1LWQ3YjM3OGFmNjdjYiIsIm5iZiI6MTQ3MDEyMjQyMCwic3ViIjoiNWVmYThhYmMtMTNkYy00NjgxLTgzZjUtYzZmZGUwNzExNmFjIn0";
            var txtSignature = "eqZkb7o6Ci_R5L2Ahi_lOm93dyGzModApP6f-FEoIJaBsctqsBrqMe_NpP-ElCDxoR1J0wc6ozr_V_r2z3CfEd2iMull7P0OWIKdQ2q9GOTHRtnByh5fms-9T_ik90KHqW-HaLMgAwQkpfnfZF_pj5eaGtn4aOH7J5EjlqOAWa7QI8CSJs4u_vxWOKTRDEupg0zjgXvdksxWjtRKb-lL2qClt32jIIe4u8f1yAyHeAyQQBC1sQs2Jl3S8EvBhBR_etW_BsNnEmD9n76aZ1H3O7nKk_yqxy6mlzcpo-JoGqFctkDFKKuzvETwHp6F5tEGFffDHJ9WB1aplZnLKeZHbw";

            var message = Encoding.UTF8.GetBytes(base64Message);
            var signature = CertHelper.FromBase64Url(txtSignature);
            var certWithPublicKey = CertHelper.LoadCertFromFile(@"C:\users\v-fexue\desktop\mycompanyname.cer");
            Console.WriteLine($"verify the ClientAssertion:{CertHelper.Verify(message, signature, certWithPublicKey)}");
        }

        public static void CreateClientAssertion()
        {
            string alg = "RS256";
            //string certThumbprint = "‎e7d4d855be6e6ce1e895405909e803339ca9f385"; //invalidate string
            string certThumbprint = "e7d4d855be6e6ce1e895405909e803339ca9f385";
            var ret = Encoding.ASCII.GetBytes(certThumbprint);
            var byteThumbprint = Enumerable.Range(0, certThumbprint.Length / 2).Select(x => Convert.ToByte(certThumbprint.Substring(x * 2, 2), 16)).ToArray();

            string x5t = CertHelper.ConvertToBase64Url(Convert.ToBase64String(byteThumbprint));

            string aud = "https:\\/\\/login.windows.net\\/o365e3w15.onmicrosoft.com\\/oauth2\\/token";
            //string exp = "1470123020";
            //string nbf = "1470122420";

            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int exp = (int)(DateTime.UtcNow - unixEpoch).TotalSeconds;
            int nbf = (int)(DateTime.UtcNow.AddMinutes(10) - unixEpoch).TotalSeconds;
            string iss = "5efa8abc-13dc-4681-83f5-c6fde07116ac";
            string sub = "5efa8abc-13dc-4681-83f5-c6fde07116ac";
            string jti = "48cd0db5-bc7c-464c-b365-d7b378af67cb";

            StringBuilder stHeader = new StringBuilder();
            stHeader.Append("{");
            stHeader.Append($"\"alg\":\"{alg}\"").Append(",");
            stHeader.Append($"\"x5t\":\"{x5t}\"");
            stHeader.Append("}");

            StringBuilder stPlayData = new StringBuilder();
            stPlayData.Append("{");
            stPlayData.Append($"\"aud\":\"{aud}\"").Append(",");
            stPlayData.Append($"\"exp\":{exp}").Append(",");
            stPlayData.Append($"\"iss\":\"{iss}\"").Append(",");
            stPlayData.Append($"\"jti\":\"{jti}\"").Append(",");
            stPlayData.Append($"\"nbf\":{nbf}").Append(",");
            stPlayData.Append($"\"sub\":\"{sub}\"");
            stPlayData.Append("}");

            string base64Header = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(CertHelper.ConvertToBase64Url(stHeader.ToString())));
            string base64UrlHeader = CertHelper.ConvertToBase64Url(base64Header);

            string base64Data = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(stPlayData.ToString()));
            string base64UrlData = CertHelper.ConvertToBase64Url(base64Data);

            string base64Message = base64UrlHeader + "." + base64UrlData;

            var cert = CertHelper.FindCert(certThumbprint);
            var base64UrlSignature = CertHelper.ConvertToBase64Url(Convert.ToBase64String(CertHelper.SignWithCertificate(base64Message, cert)));

            string clientAssertion = base64UrlHeader + "." + base64UrlData + "." + base64UrlSignature;
            Console.WriteLine(clientAssertion);
        }

        public static void TestClientAssertionRawData()
        {
            var base64Message = new string[] { "eyJhbGciOiJSUzI1NiIsIng1dCI6IjU5VFlWYjV1Yk9Ib2xVQlpDZWdETTV5cDg0VSJ9", "eyJhdWQiOiJodHRwczpcL1wvbG9naW4ud2luZG93cy5uZXRcL28zNjVlM3cxNS5vbm1pY3Jvc29mdC5jb21cL29hdXRoMlwvdG9rZW4iLCJleHAiOjE0NzAxMjMwMjAsImlzcyI6IjVlZmE4YWJjLTEzZGMtNDY4MS04M2Y1LWM2ZmRlMDcxMTZhYyIsImp0aSI6IjQ4Y2QwZGI1LWJjN2MtNDY0Yy1iMzY1LWQ3YjM3OGFmNjdjYiIsIm5iZiI6MTQ3MDEyMjQyMCwic3ViIjoiNWVmYThhYmMtMTNkYy00NjgxLTgzZjUtYzZmZGUwNzExNmFjIn0" };
            //var txtSignature = "eqZkb7o6Ci_R5L2Ahi_lOm93dyGzModApP6f-FEoIJaBsctqsBrqMe_NpP-ElCDxoR1J0wc6ozr_V_r2z3CfEd2iMull7P0OWIKdQ2q9GOTHRtnByh5fms-9T_ik90KHqW-HaLMgAwQkpfnfZF_pj5eaGtn4aOH7J5EjlqOAWa7QI8CSJs4u_vxWOKTRDEupg0zjgXvdksxWjtRKb-lL2qClt32jIIe4u8f1yAyHeAyQQBC1sQs2Jl3S8EvBhBR_etW_BsNnEmD9n76aZ1H3O7nKk_yqxy6mlzcpo-JoGqFctkDFKKuzvETwHp6F5tEGFffDHJ9WB1aplZnLKeZHbw";

            Console.WriteLine(Encoding.UTF8.GetString(CertHelper.FromBase64Url(base64Message[0])));
            Console.WriteLine(Encoding.UTF8.GetString(CertHelper.FromBase64Url(base64Message[1])));
        }

    }
}
