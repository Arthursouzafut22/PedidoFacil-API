namespace PedidoFacil.Application.DTOS.Login
{
    public record LoginRespostaDTO
    (
        string Token,
        bool EstaAutenticado,
        DateTime DataExpiracao
    );
}
