using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Login;
using PedidoFacil.Application.Interfaces;
using PedidoFacil.Application.Mappers;
using PedidoFacil.Application.Seguranca;
using PedidoFacil.Application.Services.Cliente;
using PedidoFacil.Domain.Interfaces;
using PedidoFacil.Domain.Models;
using ClienteModel = PedidoFacil.Domain.Models.Cliente;

namespace PedidoFacil.Application.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IClienteRepository _repository;
        private readonly IRefreshTokenRepository _refreshTokens;
        private readonly ITokenService _token;
        private readonly ILogger<ClienteService> _logger;
        private readonly IConfiguration _configuration;

        public LoginService(
            IClienteRepository repository,
            IRefreshTokenRepository refreshTokens,
            ITokenService token, ILogger<ClienteService> logger,
            IConfiguration configuration)
        {
            _repository = repository;
            _refreshTokens = refreshTokens;
            _token = token;
            _logger = logger;
            _configuration = configuration;
        }
        public async Task<ApiResposta<LoginRespostaDTO>> Login(LoginDTO dto)
        {
            var clienteEncontrado = await _repository.EncontrarClientePorEmail(dto.Email.ToLower());

            if (clienteEncontrado is null)
            {
                _logger.LogWarning("Tentativa de login com e-mail não cadastrado no banco de dados.");
                return ApiResposta<LoginRespostaDTO>.BadRequest(RespostaMensagem.EmailOuSenhaInvalido);
            }

            if (!BcryptService.VerificarSenha(dto.Senha, clienteEncontrado.SenhaHash))
            {
                _logger.LogWarning("Tentativa de login com senha incorreta.");
                return ApiResposta<LoginRespostaDTO>.Conflict(RespostaMensagem.EmailOuSenhaInvalido);
            }

            var token = await GerarTokens(clienteEncontrado);
            var expiracaoToken = _configuration.GetValue<int>("JwtSettings:ExpiracaoMinutos");
            var resposta = LoginMapper.MapearParaLoginRespostaDTO(token.AccessToken, token.RefreshToken, expiracaoToken);

            return ApiResposta<LoginRespostaDTO>.Ok(resposta, RespostaMensagem.LoginRealizadoComSucesso);
        }

        public async Task<ApiResposta<TokenRespostaDTO>> Refresh(string refreshToken)
        {
            var obterRefreshToken = await _refreshTokens.ObterPorTokenAsync(refreshToken);

            if (obterRefreshToken is null || !obterRefreshToken.EstaValido)
            {
                _logger.LogWarning("Tentativa de renovação de token com Refresh Token inexistente ou expirado.");
                return ApiResposta<TokenRespostaDTO>.Unauthorized(RespostaMensagem.RefreshTokenExpiradoOuInvalido);
            }

            var cliente = await _repository.EncontrarClientePorId(obterRefreshToken.ClienteId);

            if (cliente is null)
            {
                _logger.LogWarning("Tentativa de renovação de token com cliente inexistente.");
                return ApiResposta<TokenRespostaDTO>.NotFound(RespostaMensagem.ClienteNaoEncontrado);
            }

            obterRefreshToken.EstaRevogado = true;
            await _refreshTokens.Atualizar(obterRefreshToken);

            var token = await GerarTokens(cliente);

            return ApiResposta<TokenRespostaDTO>.Ok(token, RespostaMensagem.LoginRealizadoComSucesso);
        }

        public async Task<TokenRespostaDTO> GerarTokens(ClienteModel cliente)
        {
            var accessToken = _token.GerarToken(cliente);
            var refreshToken = _token.GerarRefreshToken();

            var refresh = new RefreshToken
            {
                ClienteId = cliente.Id,
                Token = refreshToken,
                DataExpiracao = DateTime.UtcNow.AddDays(7)
            };

            await _refreshTokens.Adicionar(refresh);

            return new TokenRespostaDTO(accessToken, refreshToken);
        }

    }
}
