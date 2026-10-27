using Microsoft.AspNetCore.Mvc;
using PedidoFacil.Application.DTOS.Cliente;
using PedidoFacil.Application.DTOS.Login;
using PedidoFacil.Application.Interfaces;

namespace PedidoFacil.Controllers
{
    [ApiController]
    [Route("api/autenticacao")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IClienteService _clienteservice;
        private readonly ILoginService _loginService;
        public AutenticacaoController(IClienteService service, ILoginService loginService)
        {
            _clienteservice = service;
            _loginService = loginService;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar([FromBody] CriarClienteDTO dto)
        {
            var cliente = await _clienteservice.Registrar(dto);
            return StatusCode(cliente.StatusCode, cliente);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO dto)
        {
            var login = await _loginService.Login(dto);
            return StatusCode(login.StatusCode, login);
        }
    }
}
