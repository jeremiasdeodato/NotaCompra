using MicroUniverso.AprovacaoNotasCompra.Application.Models.Usuario;

namespace MicroUniverso.AprovacaoNotasCompra.Application.Interfaces
{
    public interface IUsuarioApplication
    {
        Task<IEnumerable<UsuarioListaModel>> ObterLista();
        Task<UsuarioListaModel> ObterPorId(Guid usuarioId);
        Task Inserir(UsuarioCriacaoModel usuarioModel);
        Task Atualizar(Guid id, UsuarioAtualizacaoModel usuarioModel);
        Task Excluir(Guid id);
    }
}
