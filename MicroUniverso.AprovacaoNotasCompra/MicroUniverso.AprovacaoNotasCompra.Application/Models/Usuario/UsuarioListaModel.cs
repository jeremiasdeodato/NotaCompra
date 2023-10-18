namespace MicroUniverso.AprovacaoNotasCompra.Application.Models.Usuario
{
    public class UsuarioListaModel
    {
        public Guid Id { get; set; }
        public string? Login { get; set; }        
        public string? Papel { get; set; }
        public double ValorMinimo { get; set; }
        public double ValorMaximo { get; set; }
    }
}
