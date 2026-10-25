namespace PedidoFacil.Application.DTOS
{
    public record CriarClienteDTO(
    string nome,
    string email,
    string senha,
    string telefone
);
}
