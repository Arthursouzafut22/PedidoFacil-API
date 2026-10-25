namespace PedidoFacil.Application.Common.Responses
{
    public class ApiResposta<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public T? Data { get; set; }

        public static ApiResposta<T> Ok(T? data, string mensagem) =>
            new() { Sucesso = true, Mensagem = mensagem, Data = data, StatusCode = 200 };

        public static ApiResposta<T> NotFound(string mensagem) =>
            new() { Sucesso = false, Mensagem = mensagem, StatusCode = 404 };
    }
}
