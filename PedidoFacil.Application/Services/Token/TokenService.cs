using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PedidoFacil.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UsuarioModel = PedidoFacil.Domain.Models.Usuario;

namespace PedidoFacil.Application.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration) => _configuration = configuration;
        public string GerarToken(UsuarioModel usuario)
        {
            var chaveSecreta = _configuration.GetValue<string>("JwtSettings:SecretKey")!;
            var chaveSeguranca = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credenciaisAssinatura = new SigningCredentials(chaveSeguranca, SecurityAlgorithms.HmacSha256);
            var expiracaoToken = _configuration.GetValue<int>("JwtSettings:ExpiracaoMinutos");

            var claims = new List<Claim>()
            {
                new("id", usuario.Id.ToString()),
                new("nome", usuario.Nome),
                new("email", usuario.Email),
                new("telefone", usuario.Telefone),
                new("role", usuario.Role.ToString())
            };

            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expiracaoToken),
                signingCredentials: credenciaisAssinatura
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GerarRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
