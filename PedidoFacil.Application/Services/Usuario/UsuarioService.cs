using Microsoft.Extensions.Logging;
using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Cliente;
using PedidoFacil.Application.Interfaces;
using PedidoFacil.Application.Mappers;
using PedidoFacil.Domain.Interfaces;

namespace PedidoFacil.Application.Services.Cliente
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(IUsuarioRepository repository, ILogger<UsuarioService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApiResposta<UsuarioRespostaDTO>> Registrar(CriarUsuarioDTO dto)
        {
            var emailJaExiste = await _repository.EmailJaExiste(dto.Email);

            if (emailJaExiste)
            {
                _logger.LogWarning("Tentativa de cadastro com um e-mail já cadastrado no banco de dados.");
                return ApiResposta<UsuarioRespostaDTO>.Conflict(RespostaMensagem.EmailJaCadastrado);
            }

            if(dto.Senha != dto.ConfirmarSenha)
            {
                _logger.LogWarning("Tentativa de cadastro com senhas divergentes.");
                return ApiResposta<UsuarioRespostaDTO>.BadRequest(RespostaMensagem.SenhasNaoConferem);
            }

            var clienteModelo = UsuarioMapper.ModeloCliente(dto);

            var clienteCriado = await _repository.Criar(clienteModelo);
            var resposta = UsuarioMapper.MapearParaClienteRespostaDTO(clienteCriado);

            return ApiResposta<UsuarioRespostaDTO>.Ok(resposta, RespostaMensagem.ClienteCriadoComSucesso);
        }
    }
}
