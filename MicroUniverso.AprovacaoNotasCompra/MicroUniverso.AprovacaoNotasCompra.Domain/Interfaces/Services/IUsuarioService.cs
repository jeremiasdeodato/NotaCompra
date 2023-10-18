using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {   
        Task<IEnumerable<Usuario>> ObterLista();
        Task<Usuario?> ObterPorId(Guid usuarioId);
        Task Inserir(Usuario usuario);
        Task Excluir(Usuario usuario);
    }
}
