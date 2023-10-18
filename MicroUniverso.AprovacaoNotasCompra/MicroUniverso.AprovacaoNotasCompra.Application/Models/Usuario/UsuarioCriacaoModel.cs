using MicroUniverso.AprovacaoNotasCompra.Domain.Enums;

namespace MicroUniverso.AprovacaoNotasCompra.Application.Models.Usuario
{
    public class UsuarioCriacaoModel
    {   
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public PapelEnum? Papel { get; set; }
        public double ValorMinimo { get; set; }
        public double ValorMaximo { get; set; }
    }
}
