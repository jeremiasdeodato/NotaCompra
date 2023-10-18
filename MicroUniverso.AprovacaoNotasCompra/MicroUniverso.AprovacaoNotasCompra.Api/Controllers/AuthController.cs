using Microsoft.AspNetCore.Mvc;
using MicroUniverso.AprovacaoNotasCompra.Api.Core;
using MicroUniverso.AprovacaoNotasCompra.Application.Interfaces;
using MicroUniverso.AprovacaoNotasCompra.Application.Models.Usuario;

namespace MicroUniverso.AprovacaoNotasCompra.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase<AuthController>
    {        

        public AuthController()
        {
        }

        [HttpGet("autenticar")]
        public async Task<IActionResult> Post()
        {
            throw new NotImplementedException();
        }
    }
}