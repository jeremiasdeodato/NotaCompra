using MicroUniverso.AprovacaoNotasCompra.Domain.Entidades;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> Obter();
        Task<Usuario?> ObterPorId(Guid id);
        Task Inserir(Usuario usuario);
        Task Excluir(Usuario usuario);
    }
}
