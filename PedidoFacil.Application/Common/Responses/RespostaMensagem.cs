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
        public static string RefreshTokenExpiradoOuInvalido { get; } = "Refresh Token não encontrado ou expirado.";
        public static string CategoriaComNomeJaCadastrado { get; } = "Já existe uma categoria cadastrada com esse nome.";
        public static string CategoriaComPosicaoJaCadastrada { get; } = "Já existe uma categoria cadastrada com essa posição.";
        public static string CategoriaNaoEncontrada { get; } = "Nenhuma categoria encontrada.";
        public static string CategoriasRetornadasComSucesso { get; } = "Categorias obtidas com sucesso.";
        public static string CategoriaLocalizadaComSucesso { get; } = "Categoria localizada com sucesso.";
        public static string CategoriaCadastradaComSucesso { get; } = "Categoria cadastrada com sucesso.";
        public static string CategoriaAtualizadaComSucesso { get; } = "Categoria atualizada com sucesso.";
    }
}
