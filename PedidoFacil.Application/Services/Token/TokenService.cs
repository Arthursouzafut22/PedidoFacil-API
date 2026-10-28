using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PedidoFacil.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClienteModel = PedidoFacil.Domain.Models.Cliente;

namespace PedidoFacil.Application.Services.Token
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration) => _configuration = configuration;
        public string GerarToken(ClienteModel cliente)
        {
            var chaveSecreta = _configuration.GetValue<string>("JwtSettings:SecretKey")!;
            var chaveSeguranca = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chaveSecreta));
            var credenciaisAssinatura = new SigningCredentials(chaveSeguranca, SecurityAlgorithms.HmacSha256);
            var expiracaoToken = _configuration.GetValue<int>("JwtSettings:ExpirationHours");

            var claims = new List<Claim>()
            {
                new("id", cliente.Id.ToString()),
                new("nome", cliente.Email),
                new("email", cliente.Email),
                new("telefone", cliente.Telefone),
                new("role", cliente.Role.ToString())
            };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(expiracaoToken),
                signingCredentials: credenciaisAssinatura
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
