using Microsoft.AspNetCore.Mvc;
using PedidoFacil.Application.DTOS.Cliente;
using PedidoFacil.Application.Interfaces;

namespace PedidoFacil.Controllers
{
    [ApiController]
    [Route("api/autenticacao")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IClienteService _service;
        public AutenticacaoController(IClienteService service) => _service = service;


        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar([FromBody] CriarClienteDTO dto)
        {
            var cliente = await _service.Registrar(dto);
            return StatusCode(cliente.StatusCode, cliente);
        }
    }
}
