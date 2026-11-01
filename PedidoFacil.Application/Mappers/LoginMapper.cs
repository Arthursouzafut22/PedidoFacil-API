using PedidoFacil.Application.DTOS.Login;

namespace PedidoFacil.Application.Mappers
{
    public static class LoginMapper
    {
        public static LoginRespostaDTO MapearParaLoginRespostaDTO(
            string token,
            string refreshToken,
            int expiracaoToken)
        {
            return new LoginRespostaDTO(
                token,
                refreshToken,
                true,
                DateTime.UtcNow.AddHours(expiracaoToken)
            );
        }
    }
}