using PedidoFacil.Application.DTOS.Login;

namespace PedidoFacil.Application.Mappers
{
    public static class LoginMapper
    {
        public static LoginRespostaDTO MapearParaLoginRespostaDTO(string token, int expiracaoToken)
        {
            return new LoginRespostaDTO(token, true, DateTime.UtcNow.AddHours(expiracaoToken));
        }
    }
}
