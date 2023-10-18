using MicroUniverso.AprovacaoNotasCompra.Domain.Core.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Enums;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Entidades
{
    public class HistoricoAprovacao
    {
        public int Id{ get; set; }
        public DateTime Data { get; set; }
        public Usuario? Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public NotaCompra? NotaCompra { get; set; }
        public Guid NotaCompraId { get; set; }
        public PapelEnum Operacao { get; set; }

        public HistoricoAprovacao(DateTime data, Guid usuarioId, Guid notaCompraId, PapelEnum operacao)
        {            
            Data = data;
            UsuarioId = usuarioId;
            NotaCompraId = notaCompraId;
            Operacao = operacao;
        }
    }
}
