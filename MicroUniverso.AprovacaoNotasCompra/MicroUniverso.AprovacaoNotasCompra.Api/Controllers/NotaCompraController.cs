using Microsoft.AspNetCore.Mvc;
using MicroUniverso.AprovacaoNotasCompra.Api.Core;
using MicroUniverso.AprovacaoNotasCompra.Application.Interfaces;

namespace MicroUniverso.AprovacaoNotasCompra.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaCompraController : ControllerBase<NotaCompraController>
    {
        private readonly INotaCompraApplication _notaCompraApplication;

        public NotaCompraController(INotaCompraApplication notaCompraApplication)
        {
            _notaCompraApplication = notaCompraApplication;
        }

        [HttpGet("pendentes/{usuarioId}")]
        public async Task<IActionResult> ObterNotasPendentesAprovacao(Guid usuarioId)
        {
            var notasPendentes = await _notaCompraApplication.ObterNotasPendentesAprovacao(usuarioId);
            return ResponseGet(notasPendentes);
        }

        [HttpPost("aprovar/{notaCompraId}/{usuarioId}")]
        public async Task<IActionResult> AprovarNotaCompra(Guid notaCompraId, Guid usuarioId)
        {
            await _notaCompraApplication.AprovarNotaCompra(notaCompraId, usuarioId);
            return ResponsePost("Nota de compra aprovada com sucesso.");
        }

        [HttpPost("registrarvisto/{notaCompraId}/{usuarioId}")]
        public async Task<IActionResult> RegistrarVisto(Guid notaCompraId, Guid usuarioId)
        {
            await _notaCompraApplication.RegistrarVisto(notaCompraId, usuarioId);
            return ResponsePost("Visto registrado com sucesso.");
        }
    }
}