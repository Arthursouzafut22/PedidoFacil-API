using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PedidoFacil.Application.DTOS.Categoria;
using PedidoFacil.Application.Interfaces;

namespace PedidoFacil.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> BuscarTodasCategoria()
        {
            var categorias = await _service.BuscarTodasCategoria();
            return StatusCode(categorias.StatusCode, categorias);
        }

        [HttpGet("por-id/{id?}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> BuscarCategoriaPorId(Guid? id)
        {
            var categoria = await _service.BuscarCategoriaPorId(id);
            return StatusCode(categoria.StatusCode, categoria);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> CadastrarCategoria([FromBody] CriarCategoriaDTO dto)
        {
            var usuarioId = User.FindFirst("id")!.Value;
            var categoria = await _service.CadastrarCategoria(dto, Guid.Parse(usuarioId));
            return StatusCode(categoria.StatusCode, categoria);
        }

        [HttpPut("{id?}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> AtualizarCategoria(Guid? id, [FromBody] AtualizarCategoriaDTO dto)
        {
            var usuarioId = User.FindFirst("id")!.Value;
            var categoria = await _service.AtualizarCategoria(dto, id, Guid.Parse(usuarioId));
            return StatusCode(categoria.StatusCode, categoria);
        }

        [HttpDelete("{id?}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> DeletarCategoria(Guid id)
        {
            var usuarioId = User.FindFirst("id")!.Value;
            var categoria = await _service.DeletarCategoria(id, Guid.Parse(usuarioId));
            return StatusCode(categoria.StatusCode, categoria);
        }
    }
}
