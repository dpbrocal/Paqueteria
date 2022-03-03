
using System;
using System.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Paqueteria.Services.Security
{
    /// <summary>
    /// JWT Token generator class using "secret-key"
    /// </summary>
    internal static class TokenGenerator
    {
        public static string GenerateTokenJwt(string username, JWTSettings jwtSettings)
        {
            //TODO: appsetting for Demo JWT - protect correctly this settings

            var secretKey = jwtSettings.SecretKey;
            var expireTime = jwtSettings.ExpireTime;
            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            
            // create token to the user 
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddMinutes(Convert.ToDouble(expireTime)),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtTokenString = tokenHandler.WriteToken(token);
            return jwtTokenString;
        }
    }
}
