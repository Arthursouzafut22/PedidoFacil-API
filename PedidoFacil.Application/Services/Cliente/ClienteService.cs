using Microsoft.Extensions.Logging;
using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Cliente;
using PedidoFacil.Application.Interfaces;
using PedidoFacil.Application.Mappers;
using PedidoFacil.Domain.Interfaces;

namespace PedidoFacil.Application.Services.Cliente
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly ILogger<ClienteService> _logger;

        public ClienteService(IClienteRepository repository, ILogger<ClienteService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ApiResposta<ClienteRespostaDTO>> Registrar(CriarClienteDTO dto)
        {
            var emailJaExiste = await _repository.EmailJaExiste(dto.Email);

            if (emailJaExiste)
            {
                _logger.LogWarning("Tentativa de cadastro com um e-mail já cadastrado no banco de dados.");
                return ApiResposta<ClienteRespostaDTO>.Conflict(RespostaMensagem.EmailJaCadastrado);
            }

            if(dto.Senha != dto.ConfirmarSenha)
            {
                _logger.LogWarning("Tentativa de cadastro com senhas divergentes.");
                return ApiResposta<ClienteRespostaDTO>.Conflict(RespostaMensagem.SenhasNaoConferem);
            }

            var clienteModelo = ClienteMapper.ModeloCliente(dto);

            var clienteCriado = await _repository.Criar(clienteModelo);
            var resposta = ClienteMapper.MapearParaClienteRespostaDTO(clienteCriado);

            return ApiResposta<ClienteRespostaDTO>.Ok(resposta, RespostaMensagem.ClienteCriadoComSucesso);
        }
    }
}
