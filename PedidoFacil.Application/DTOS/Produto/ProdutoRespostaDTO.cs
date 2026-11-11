namespace PedidoFacil.Application.DTOS.Produto
{
    public record ProdutoRespostaDTO
    (
        string Nome,
        string Descricao,
        decimal Preco,
        bool Disponivel,
        string ImagemUrl,
        Guid CategoriaId
    );
}
