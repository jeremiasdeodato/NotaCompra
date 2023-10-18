using Microsoft.AspNetCore.Mvc;
using MicroUniverso.AprovacaoNotasCompra.Api.Core;
using MicroUniverso.AprovacaoNotasCompra.Application.Interfaces;
using MicroUniverso.AprovacaoNotasCompra.Application.Models.Usuario;

namespace MicroUniverso.AprovacaoNotasCompra.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase<UsuarioController>
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public UsuarioController(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;
        }

        [HttpGet("consultar")]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _usuarioApplication.ObterLista();
            return ResponseGet(usuarios);
        }

        [HttpGet("consultar/{idUsuario}")]
        public async Task<IActionResult> Get(Guid idUsuario)
        {
            var usuario = await _usuarioApplication.ObterPorId(idUsuario);
            return ResponseGet(usuario);
        }
        
        [HttpPost("inserir")]
        public async Task<IActionResult> Post(UsuarioCriacaoModel usuarioModel)
        {
            await _usuarioApplication.Inserir(usuarioModel);

            return ResponsePost("Usuário Inserido com sucesso");
        }
        
        [HttpPut("atualizar/{usuarioId}")]        
        public async Task<IActionResult> Put(Guid usuarioId, UsuarioAtualizacaoModel usuarioModel)
        {
            await _usuarioApplication.Atualizar(usuarioId, usuarioModel);

            return ResponsePost("Usuário atualizado com sucesso");
        }

        [HttpDelete("excluir/{usuarioId}")]        
        public async Task<IActionResult> Delete(Guid usuarioId)
        {
            await _usuarioApplication.Excluir(usuarioId);

            return ResponsePost("Usuário excluído com sucesso");
        }
    }
}