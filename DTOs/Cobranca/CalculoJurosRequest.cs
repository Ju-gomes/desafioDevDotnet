namespace DesafioDevDotnet.DTOs.Cobranca
{
    public class CalculoJurosRequest
    {
        public decimal ValorOriginal { get; set; }
        public DateTime DataVencimento { get; set; }
    }
}
