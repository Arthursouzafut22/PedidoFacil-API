namespace PedidoFacil.Application.Seguranca
{
    public class BcryptService
    {
        public static string GerarHashSenha(string senha)
            => BCrypt.Net.BCrypt.HashPassword(senha);

        public static bool VerificarSenha(string senha, string senhaHash)
            => BCrypt.Net.BCrypt.Verify(senha, senhaHash);
    }
}
