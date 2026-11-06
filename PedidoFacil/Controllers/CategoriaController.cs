using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PedidoFacil.Application.DTOS.Categoria;
using PedidoFacil.Application.Interfaces;

namespace PedidoFacil.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> BuscarTodasCategoria()
        {
            return StatusCode(200);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> BuscarCategoriaPorId(Guid id)
        {
            return StatusCode(200);
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> CadastrarCategoria([FromBody] CriarCategoriaDTO dto)
        {
            var categoria = await _service.CadastrarCategoria(dto);
            return StatusCode(categoria.StatusCode, categoria);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> AtualizarCategoria(Guid id)
        {
            return StatusCode(200);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<ActionResult> DeletarCategoria(Guid id)
        {
            return StatusCode(200);
        }
    }
}
