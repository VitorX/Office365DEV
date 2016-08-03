using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ADALSamples
{
    class CertHelper
    {

        public static X509Certificate2 FindCert(string thumbprint)
        {
            return FindCert(thumbprint, "MY", StoreLocation.CurrentUser);
        }

        public static X509Certificate2 FindCert(string thumbprint, string storeName, StoreLocation storeLocation)
        {
            thumbprint = thumbprint.Replace("\u200e", string.Empty).Replace("\u200f", string.Empty).Replace(" ", string.Empty);
            X509Store store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection fcollection = (X509Certificate2Collection)collection.Find(X509FindType.FindByThumbprint, thumbprint, false);
            return fcollection[0];
        }

        public static X509Certificate2 LoadCertFromFile(string filePath)
        {
            X509Certificate2 x509 = new X509Certificate2();
            x509.Import(filePath);
            return x509;
        }

        public static byte[] SignWithCertificate(string message, X509Certificate2 certificate)
        {
            if (certificate.PublicKey.Key.KeySize < ClientAssertionCertificate.MinKeySizeInBits)
            {
                throw new ArgumentOutOfRangeException("rawData", string.Format(CultureInfo.InvariantCulture, "The certificate used must have a key size of at least {0} bits", new object[]
                {
            ClientAssertionCertificate.MinKeySizeInBits
                }));
            }
            RSACryptoServiceProvider rSACryptoServiceProvider = new X509AsymmetricSecurityKey(certificate).GetAsymmetricAlgorithm("http://www.w3.org/2001/04/xmldsig-more#rsa-sha256", true) as RSACryptoServiceProvider;
            RSACryptoServiceProvider rSACryptoServiceProvider2 = null;
            byte[] result;
            try
            {
                rSACryptoServiceProvider2 = GetCryptoProviderForSha256(rSACryptoServiceProvider);
                using (SHA256Cng sHA256Cng = new SHA256Cng())
                {
                    result = rSACryptoServiceProvider2.SignData(Encoding.UTF8.GetBytes(message), sHA256Cng);
                }
            }
            finally
            {
                if (rSACryptoServiceProvider2 != null && rSACryptoServiceProvider != rSACryptoServiceProvider2)
                {
                    rSACryptoServiceProvider2.Dispose();
                }
            }
            return result;
        }

        private static RSACryptoServiceProvider GetCryptoProviderForSha256(RSACryptoServiceProvider rsaProvider)
        {
            if ((rsaProvider.CspKeyContainerInfo.ProviderType == 1 || rsaProvider.CspKeyContainerInfo.ProviderType == 12) && !rsaProvider.CspKeyContainerInfo.HardwareDevice)
            {
                CspParameters cspParameters = new CspParameters
                {
                    ProviderType = 24,
                    KeyContainerName = rsaProvider.CspKeyContainerInfo.KeyContainerName,
                    KeyNumber = (int)rsaProvider.CspKeyContainerInfo.KeyNumber
                };
                if (rsaProvider.CspKeyContainerInfo.MachineKeyStore)
                {
                    cspParameters.Flags = CspProviderFlags.UseMachineKeyStore;
                }
                cspParameters.Flags |= CspProviderFlags.UseExistingKey;
                return new RSACryptoServiceProvider(cspParameters);
            }
            return rsaProvider;
        }

        public static bool Verify(string message, byte[] signature, X509Certificate2 cert)
        {
            RSACryptoServiceProvider rSACryptoServiceProvider = cert.PublicKey.Key as RSACryptoServiceProvider;
            RSACryptoServiceProvider rSACryptoServiceProvider2 = null;
            bool isVerified = false;
            try
            {
                rSACryptoServiceProvider2 = GetCryptoProviderForSha256(rSACryptoServiceProvider);
                using (SHA256Cng sHA256Cng = new SHA256Cng())
                {
                    isVerified = rSACryptoServiceProvider2.VerifyData(Encoding.UTF8.GetBytes(message), sHA256Cng, signature);
                }
            }
            finally
            {
                if (rSACryptoServiceProvider2 != null && rSACryptoServiceProvider != rSACryptoServiceProvider2)
                {
                    rSACryptoServiceProvider2.Dispose();
                }
            }
            return isVerified;
        }

        public static bool Verify(byte[] message, byte[] signature, X509Certificate2 cert)
        {
            RSACryptoServiceProvider rSACryptoServiceProvider = cert.PublicKey.Key as RSACryptoServiceProvider;
            RSACryptoServiceProvider rSACryptoServiceProvider2 = null;
            bool isVerified = false;
            try
            {
                rSACryptoServiceProvider2 = GetCryptoProviderForSha256(rSACryptoServiceProvider);
                using (SHA256Cng sHA256Cng = new SHA256Cng())
                {
                    isVerified = rSACryptoServiceProvider2.VerifyData(message, sHA256Cng, signature);
                }
            }
            finally
            {
                if (rSACryptoServiceProvider2 != null && rSACryptoServiceProvider != rSACryptoServiceProvider2)
                {
                    rSACryptoServiceProvider2.Dispose();
                }
            }
            return isVerified;
        }

        public static byte[] FromBase64Url(string base64Url)
        {
            string padded = base64Url.Length % 4 == 0
                ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
            string base64 = padded.Replace("_", "/")
                                  .Replace("-", "+");
            return Convert.FromBase64String(base64);
        }

        public static string ConvertToBase64Url(string base64)
        {
            //char Base64Character62 = '+';
            //char Base64Character63 = '/';
            //char Base64UrlCharacter62 = '-';
            //char Base64UrlCharacter63 = '_';
            base64 = base64.Replace("=", "");
            string base64Url = base64.Replace("/", "_")
                            .Replace("+", "-");
            return base64Url;

        }

        public static string ConvertToBase64(string base64Url)
        {
            string padded = base64Url.Length % 4 == 0
                ? base64Url : base64Url + "====".Substring(base64Url.Length % 4);
            string base64 = padded.Replace("_", "/")
                                  .Replace("-", "+");
            return base64;
        }

    }
}
