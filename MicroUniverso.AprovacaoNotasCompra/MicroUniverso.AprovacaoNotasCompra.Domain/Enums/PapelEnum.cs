using System.ComponentModel;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Enums
{
    public enum PapelEnum : short
    {
        [Description("Visto")]
        Visto = 1,

        [Description("Aprovação")]
        Aprovacao = 2
    }
}
