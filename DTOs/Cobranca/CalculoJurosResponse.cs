namespace DesafioDevDotnet.DTOs.Cobranca
{
    public class CalculoJurosResponse
    {
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataCalculo { get; set; }
        public int DiasAtraso { get; set; }
        public decimal TaxaMultaDiariaPorcentagem { get; set; }
        public decimal ValorMultaJuros { get; set; }
        public decimal ValorTotalAtualizado { get; set; }
    }
}
