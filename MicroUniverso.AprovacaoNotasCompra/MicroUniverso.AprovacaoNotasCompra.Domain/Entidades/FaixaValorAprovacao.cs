namespace MicroUniverso.AprovacaoNotasCompra.Domain.Entidades
{
    public class FaixaValorAprovacao
    {
        public int Id { get; set; }
        public double ValorMinimo { get; set; }
        public double ValorMaximo { get; set; }
        public int VistosNecessarios { get; set; }
        public int AprovacoesNecessarias { get; set; }
    }
}
