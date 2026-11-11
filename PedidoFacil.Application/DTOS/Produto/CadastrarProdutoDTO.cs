namespace PedidoFacil.Application.DTOS.Produto
{
    public record CadastrarProdutoDTO
    (
        string Nome,
        string Descricao,
        decimal Preco,
        bool Disponivel,
        Guid CategoriaId,
        Guid UsuarioId
    );
}
