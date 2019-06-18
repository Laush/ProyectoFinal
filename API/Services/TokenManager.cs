using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Claims;
using System.Web;
using Genericas;
using System.IdentityModel.Tokens.Jwt;

namespace API.Services
{
    public class TokenManager
    {
        public static string GenerateTokenJwt(Usuario Usuario)
        {
            // appsetting for Token JWT
            var secretKey = ConfigurationManager.AppSettings["JWT_SECRET_KEY"];
            var audienceToken = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"];
            var issuerToken = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"];
            var expireTime = ConfigurationManager.AppSettings["JWT_EXPIRE_DAYS"];


            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);


            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, Usuario.NombreUsuario),
                new Claim(ClaimTypes.Email, Usuario.Email),
                new Claim("Id", Usuario.IdUsuario.ToString())
            });


            // create token to the user
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(Convert.ToInt32(expireTime)), //Si puedde ser nulo este dato,
                //entonces se puede remover la variable de sistema que fija el tiempo de expiracion
                signingCredentials: signingCredentials);


            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }

        public long GetUserId(string Token)
        {
            int IdUsuario;
            JwtSecurityTokenHandler TokenHandler = new JwtSecurityTokenHandler();

            JwtSecurityToken SecurityToken = TokenHandler.ReadJwtToken(Token);

            IEnumerable<Claim> Claims = SecurityToken.Claims;

            int.TryParse(Claims.FirstOrDefault(c => c.Type == "Id").Value, out IdUsuario);

            return IdUsuario;
        }
    }
}