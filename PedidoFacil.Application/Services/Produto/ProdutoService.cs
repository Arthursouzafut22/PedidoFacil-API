using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PedidoFacil.Application.Common.Responses;
using PedidoFacil.Application.DTOS.Produto;
using PedidoFacil.Application.Interfaces;
using PedidoFacil.Domain.Interfaces;

namespace PedidoFacil.Application.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly ILogger<ProdutoService> _logger;
        private readonly ISupaBaseService _supaBaseService;

        public ProdutoService(
            IProdutoRepository repository, 
            ILogger<ProdutoService> logger,
            ISupaBaseService supaBaseService)
        {
            _repository = repository;
            _logger = logger;
            _supaBaseService = supaBaseService;
        }
        public async Task<ApiResposta<ProdutoRespostaDTO>> CadastrarProduto(
            CadastrarProdutoDTO dto, IFormFile imagemProduto, Guid usuarioId)
        {
            var imagemUrl = await _supaBaseService.SalvarImagem(imagemProduto);
            throw new NotImplementedException();
        }
    }
}
