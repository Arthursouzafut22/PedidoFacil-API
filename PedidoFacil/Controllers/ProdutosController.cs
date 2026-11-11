using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PedidoFacil.Application.DTOS.Produto;
using PedidoFacil.Application.Interfaces;

namespace PedidoFacil.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CadastrarProduto(
            [FromBody] CadastrarProdutoDTO dto, IFormFile imagemProduto)
        {
            var usuarioId = User.FindFirst("id")!.Value;
            var produto = await _service.CadastrarProduto(dto, imagemProduto, Guid.Parse(usuarioId));
            return StatusCode(produto.StatusCode, produto);
        }
    }
}
