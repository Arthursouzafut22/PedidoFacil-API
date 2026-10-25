using Microsoft.AspNetCore.Mvc;
using PedidoFacil.Application.DTOS;

namespace PedidoFacil.Controllers
{
    [ApiController]
    [Route("api/autenticacao")]
    public class AutenticacaoController : ControllerBase
    {
        [HttpGet("registrar")]
        public async Task<ActionResult> Registrar([FromBody] CriarClienteDTO cliente)
        {
            return StatusCode(200, null);
        }
    }
}
