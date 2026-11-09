using PedidoFacil.Application.DTOS.Cliente;
using PedidoFacil.Domain.Models;
using PedidoFacil.Application.Seguranca;

namespace PedidoFacil.Application.Mappers
{
    public static class UsuarioMapper
    {
        public static Usuario ModeloCliente(CriarUsuarioDTO dto) =>
            new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone,
                SenhaHash = BcryptService.GerarHashSenha(dto.Senha)
            };

        public static UsuarioRespostaDTO MapearParaClienteRespostaDTO(Usuario cliente) =>
            new UsuarioRespostaDTO(cliente.Nome, cliente.Email, cliente.Telefone);
    }
}