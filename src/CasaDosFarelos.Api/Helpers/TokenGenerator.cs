using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CasaDosFarelos.Api.Helpers
{
    public static class TokenGenerator
    {
        public static string GerarTokenGerente()
        {
            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("F3rR@c0_C@saD0sF@r3l0s_2026!Jwt#256Bits$Secure"));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Gerente Teste"),
                new Claim(ClaimTypes.Role, "Gerente")
            };

            var token = new JwtSecurityToken(
                issuer: "CasaDosFarelos",
                audience: "CasaDosFarelos",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credenciais
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}