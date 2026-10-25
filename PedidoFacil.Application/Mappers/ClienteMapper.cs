using PedidoFacil.Application.DTOS.Cliente;
using PedidoFacil.Domain.Models;
using PedidoFacil.Application.Seguranca;

namespace PedidoFacil.Application.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente ModeloCliente(CriarClienteDTO dto) =>
            new Cliente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                SenhaHash = BcryptService.GerarHashSenha(dto.Senha)
            };

        public static ClienteRespostaDTO MapearParaClienteRespostaDTO(Cliente cliente) =>
            new ClienteRespostaDTO(cliente.Nome, cliente.Email, cliente.Telefone);
    }
}