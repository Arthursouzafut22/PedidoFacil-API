namespace PedidoFacil.Application.DTOS.Login
{
    public record TokenRespostaDTO
    (
        string AccessToken, 
        string RefreshToken
    );
}
