using System.ComponentModel;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Enums
{
    public enum StatusEnum : short
    {
        [Description("Pendente")]
        Pendente = 1,

        [Description("Aprovada")]
        Aprovada = 2
    }
}
