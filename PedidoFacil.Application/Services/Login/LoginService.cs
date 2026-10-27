using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Login;
using PedidoFacil.Application.Interfaces;
using PedidoFacil.Application.Mappers;
using PedidoFacil.Application.Seguranca;
using PedidoFacil.Application.Services.Cliente;
using PedidoFacil.Domain.Interfaces;

namespace PedidoFacil.Application.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly IClienteRepository _repository;
        private readonly ITokenService _token;
        private readonly ILogger<ClienteService> _logger;
        private readonly IConfiguration _configuration;

        public LoginService(IClienteRepository repository,
            ITokenService token, ILogger<ClienteService> logger,
            IConfiguration configuration)
        {
            _repository = repository;
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

            var token = _token.GerarToken(clienteEncontrado);
            var expiracaoToken = _configuration.GetValue<int>("JwtSettings:ExpirationHours");
            var resposta = LoginMapper.MapearParaLoginRespostaDTO(token, expiracaoToken);

            return ApiResposta<LoginRespostaDTO>.Ok(resposta, RespostaMensagem.LoginRealizadoComSucesso);
        }
    }
}
