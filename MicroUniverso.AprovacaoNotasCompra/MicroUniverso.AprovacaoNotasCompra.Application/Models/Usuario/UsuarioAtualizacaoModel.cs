using MicroUniverso.AprovacaoNotasCompra.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace MicroUniverso.AprovacaoNotasCompra.Application.Models.Usuario
{
    public class UsuarioAtualizacaoModel
    {
        [Required(ErrorMessage = "Login é obrigatório!")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Papel é obrigatório!")]
        public PapelEnum? Papel { get; set; }

        [Required(ErrorMessage = "ValorMinimo é obrigatório!")]
        public double ValorMinimo { get; set; }

        [Required(ErrorMessage = "ValorMaximo é obrigatório!")]
        public double ValorMaximo { get; set; }
    }
}
