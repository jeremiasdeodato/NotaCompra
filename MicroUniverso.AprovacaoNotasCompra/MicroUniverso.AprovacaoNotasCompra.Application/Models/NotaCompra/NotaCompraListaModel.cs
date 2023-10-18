using MicroUniverso.AprovacaoNotasCompra.Domain.Enums;

namespace MicroUniverso.AprovacaoNotasCompra.Application.Models.Autorizacao
{
    public class NotaCompraListaModel
    {
        public Guid Id { get; set; }
        public DateTime DataDeEmissao { get; set; }        
        public double ValorTotal { get; set; }
        public string? Status { get; set; }
    }
}
