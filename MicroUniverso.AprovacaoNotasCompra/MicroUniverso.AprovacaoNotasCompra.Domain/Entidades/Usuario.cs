using MicroUniverso.AprovacaoNotasCompra.Domain.Core.Entidades;
using MicroUniverso.AprovacaoNotasCompra.Domain.Enums;

namespace MicroUniverso.AprovacaoNotasCompra.Domain.Entidades
{
    public class Usuario : EntidadeBase
    {
        public string? Login { get; set; }
        public string? Senha { get; set; }
        public PapelEnum? Papel { get; set; }
        public double ValorMinimo { get; set; }
        public double ValorMaximo { get; set; }

        public Usuario(string? login, string? senha, PapelEnum? papel, double valorMinimo, double valorMaximo)
        {
            Login = login;
            Senha = senha;
            Papel = papel;
            ValorMinimo = valorMinimo;
            ValorMaximo = valorMaximo;
        }

        public void AtualizarLogin(string login)
        {
            Login = login;
        }

        public void AtualizarPapel(PapelEnum? papel)
        {
            Papel = papel;
        }

        public void AtualizarValorMinimo(double valorMinimo)
        {
            ValorMinimo = valorMinimo;
        }

        public void AtualizarValorMaximo(double valorMaximo)
        {
            ValorMaximo = valorMaximo;
        }

        private string? ValidarUsuario()
        {
            if (Login == null)
                return $"Campo {nameof(Login)} é obrigatório e não pode ser nulo.";

            if (Senha == null)
                return $"Campo {nameof(Senha)} é obrigatório e não pode ser nulo.";

            if (Papel == null)
                return $"Campo {nameof(Papel)} é obrigatório e não pode ser nulo.";

            return null;
        }

        public override bool EhValido()
        {
            return ValidarUsuario() == null;
        }

        public override string? MensagemValidacao()
        {
            var validarUsuario = ValidarUsuario();

            if (validarUsuario == null)
                return null;
            else
                return validarUsuario;
        }
    }
}
