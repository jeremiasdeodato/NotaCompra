using MicroUniverso.AprovacaoNotasCompra.Domain.Enums;

namespace MicroUniverso.AprovacaoNotasCompra.Application.Models.Autorizacao
{
    public class NotaCompraModel
    {
        public Guid Id { get; set; }
        public DateTime DataDeEmissao { get; set; }
        public double ValorMercadorias { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorFrete { get; set; }
        public double ValorTotal { get; set; }
        public StatusEnum Status { get; set; }
    }
}
