
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Protocols;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ADALSamples
{
    public partial class TokenHelper
    {
        private string MetadataAddress = "[Your Federation Metadata document address goes here]";

        //Validates the JWT Token that's part of the Authorization header in an HTTP request.
        //public void ValidateJwtToken(string token)
        //{
        //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler()
        //    {
        //        // Do not disable for production code
        //        CertificateValidator = X509CertificateValidator.None
        //    };

        //    TokenValidationParameters validationParams = new TokenValidationParameters()
        //    {
        //        AllowedAudience = "[Your App ID URI goes here, as registered in the Azure Classic Portal]",
        //        ValidIssuer = "[The issuer for the token goes here, such as https://sts.windows.net/68b98905-130e-4d7c-b6e1-a158a9ed8449/]",
        //        SigningTokens = GetSigningCertificates(MetadataAddress)

        //        // Cache the signing tokens by your desired mechanism
        //    };

        //    Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationParams);
        //}

        // Returns a list of certificates from the specified metadata document.
        //public List<X509SecurityToken> GetSigningCertificates(string metadataAddress)
        //{
        //    List<X509SecurityToken> tokens = new List<X509SecurityToken>();

        //    if (metadataAddress == null)
        //    {
        //        throw new ArgumentNullException(metadataAddress);
        //    }

        //    using (XmlReader metadataReader = XmlReader.Create(metadataAddress))
        //    {
        //        MetadataSerializer serializer = new MetadataSerializer()
        //        {
        //            // Do not disable for production code
        //            CertificateValidationMode = X509CertificateValidationMode.None
        //        };

        //        EntityDescriptor metadata = serializer.ReadMetadata(metadataReader) as EntityDescriptor;

        //        if (metadata != null)
        //        {
        //            SecurityTokenServiceDescriptor stsd = metadata.RoleDescriptors.OfType<SecurityTokenServiceDescriptor>().First();

        //            if (stsd != null)
        //            {
        //                IEnumerable<X509RawDataKeyIdentifierClause> x509DataClauses = stsd.Keys.Where(key => key.KeyInfo != null && (key.Use == KeyType.Signing || key.Use == KeyType.Unspecified)).
        //                                                     Select(key => key.KeyInfo.OfType<X509RawDataKeyIdentifierClause>().First());

        //                tokens.AddRange(x509DataClauses.Select(token => new X509SecurityToken(new X509Certificate2(token.GetX509RawData()))));
        //            }
        //            else
        //            {
        //                throw new InvalidOperationException("There is no RoleDescriptor of type SecurityTokenServiceType in the metadata");
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("Invalid Federation Metadata document");
        //        }
        //    }
        //    return tokens;
        //}

        /// <summary>
        /// work for version 4.0.30826.1200
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        //public JwtSecurityToken Validate(string token)
        //{
        //    string stsDiscoveryEndpoint = "https://login.microsoftonline.com/common/v2.0/.well-known/openid-configuration";

        //    ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint);

        //    OpenIdConnectConfiguration config = configManager.GetConfigurationAsync().Result;

        //    TokenValidationParameters validationParameters = new TokenValidationParameters
        //    {
        //        ValidateAudience = false,
        //        ValidateIssuer = false,
        //        IssuerSigningTokens = config.SigningTokens,
        //        ValidateLifetime = false
        //    };

        //    JwtSecurityTokenHandler tokendHandler = new JwtSecurityTokenHandler();

        //    SecurityToken jwt;

        //    var result = tokendHandler.ValidateToken(token, validationParameters, out jwt);

        //    return jwt as JwtSecurityToken;
        //}


        //public Microsoft.IdentityModel.Tokens.SecurityToken Validate(string accessToken)
        //{
        //    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        //    TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
        //    {
        //        ValidateAudience = false,
        //        ValidateIssuer = false,
        //        ValidateLifetime = false
        //    };
        //    Microsoft.IdentityModel.Tokens.SecurityToken securityToken;
        //    tokenHandler.ValidateToken(accessToken, tokenValidationParameters, out securityToken);

        //    return securityToken;
        //}
    }


}



