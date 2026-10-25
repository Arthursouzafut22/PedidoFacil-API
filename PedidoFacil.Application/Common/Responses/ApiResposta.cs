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

        public static ApiResposta<T> Unauthorized(string mensagem) =>
            new() { Sucesso = false, Mensagem = mensagem, StatusCode = 401 };

        public static ApiResposta<T> Conflict(string mensagem) =>
            new() { Sucesso = false, Mensagem = mensagem, StatusCode = 409 };

        public static ApiResposta<T> Forbidden(string mensagem) =>
             new() { Sucesso = false, Mensagem = mensagem, StatusCode = 403 };

        public static ApiResposta<T> NoContent(string mensagem) =>
            new() { Sucesso = false, Mensagem = mensagem, StatusCode = 204 };

        public static ApiResposta<T> BadRequest(string mensagem) =>
            new() { Sucesso = false, Mensagem = mensagem, StatusCode = 400 };
    }
}
