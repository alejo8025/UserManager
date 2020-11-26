using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManager.Domain.Auth;
using UserManager.Model.Auth;
using UserManager.Model.Common;

namespace UserManager.Infrastructure.Auth
{
    public class AuthRepository : IAuth
    {
        private readonly AppSettingGlobal globalSettings;
        public AuthRepository(AppSettingGlobal settings)
        {
            globalSettings = settings;
        }
        public Task<Token> GenerateToken(string clientid, string secretkey)
        {

            var responseToken = new Token();
            var expiresToken = DateTime.Now.AddHours(3);
            var header = new JwtHeader(
                new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretkey)),
                    SecurityAlgorithms.HmacSha256)
                );

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, clientid)
            };
            var payload = new JwtPayload(
                issuer: globalSettings.GetValue("Issuer"),
                audience: globalSettings.GetValue("Audience"),
                claims: claims,
                notBefore: DateTime.Now,
                expires: expiresToken
            );

            var token = new JwtSecurityToken(header, payload);
            responseToken.AccessToken = new JwtSecurityTokenHandler().WriteToken(token);
            responseToken.Expires = expiresToken;

            return Task.FromResult(responseToken);
        }

        public Task<Credential> GetCredentials()
        {
            Credential credential = new Credential();
            
            var clientIdAuth = globalSettings.GetValue("ClientIdAuth");
            if (!string.IsNullOrEmpty(clientIdAuth))
            {
                credential.ClientID = clientIdAuth;
                credential.SecretKey = globalSettings.GetValue("SecretKeyAuth");
            }

            return Task.FromResult(credential);
        }
    }
}
