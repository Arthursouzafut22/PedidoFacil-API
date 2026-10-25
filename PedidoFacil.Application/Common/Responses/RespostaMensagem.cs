namespace PedidoFacil.Application.Common.Responses
{
    public static class RespostaMensagem
    {
        public static string ClienteNaoEncontrado { get; } = "Cliente não encontrado.";
        public static string ClienteCriadoComSucesso { get; } = "Cliente criado com sucesso.";
        public static string EmailJaCadastrado { get; } = "E-mail já cadastrado.";
        public static string SenhasNaoConferem { get; } = "As senhas não conferem.";
        public static string EmailOuSenhaInvalido { get; } = "E-mail ou senha inválidos.";
        public static string LoginRealizadoComSucesso { get; } = "Login realizado com sucesso.";
    }
}
