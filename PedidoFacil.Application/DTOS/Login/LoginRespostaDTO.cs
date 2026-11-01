namespace PedidoFacil.Application.DTOS.Login
{
    public record LoginRespostaDTO
    (
        string Token,
        string RefreshToken,
        bool EstaAutenticado,
        DateTime DataExpiracao
    );
}
