using MicroUniverso.AprovacaoNotasCompra.Domain.Core.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Enums;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Entidades
{
    public class NotaCompra : EntidadeBase
    {
        public DateTime DataDeEmissao { get; set; }
        public double ValorMercadorias { get; set; }
        public double ValorDesconto { get; set; }
        public double ValorFrete { get; set; }
        public double ValorTotal { get; set; }
        public StatusEnum Status { get; set; }

        public void AtualizarStatus(StatusEnum status)
        {
            Status = status;
        }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }

        public override string? MensagemValidacao()
        {
            throw new NotImplementedException();
        }
    }
}
