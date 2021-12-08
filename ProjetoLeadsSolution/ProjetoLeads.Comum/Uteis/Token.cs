using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLeads.Comum.Utils
{
    public class Token
    {
        public Token(string issuer, string audience, string secretKey)
        {
            Issuer = issuer;
            Audience = audience;
            SecretKey = secretKey;
        }

        public string Issuer { get; private set; }
        public string Audience { get; private set; }
        public string SecretKey { get; private set; }

        public string GerarJWT(Guid id, string nome, string email, EnTipoUsuario tipoUsuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Name, nome),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("Role", tipoUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, id.ToString())
            };

            var token = new JwtSecurityToken(
                    Issuer,
                    Audience,
                    claims,
                    expires: DateTime.Now.AddHours(2),
                    signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}
