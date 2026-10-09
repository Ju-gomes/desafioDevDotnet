using DesafioDevDotnet.DTOs.Cobranca;
using DesafioDevDotnet.Services.Interfaces;

namespace DesafioDevDotnet.Services
{
    public class CobrancaService : ICobrancaService
    {
        private const decimal TaxaMultaDiaria = 0.025m; // 2,5% ao dia[cite: 1]

        public CalculoJurosResponse CalcularJuros(CalculoJurosRequest request)
        {
            var dataHoje = DateTime.Today;
            var dataVencimento = request.DataVencimento.Date;

            int diasAtraso = (dataHoje - dataVencimento).Days;
            if (diasAtraso < 0)
                diasAtraso = 0;

            decimal valorMulta = request.ValorOriginal * (TaxaMultaDiaria * diasAtraso);
            decimal valorTotal = request.ValorOriginal + valorMulta;

            return new CalculoJurosResponse
            {
                ValorOriginal = request.ValorOriginal,
                DataVencimento = dataVencimento,
                DataCalculo = dataHoje,
                DiasAtraso = diasAtraso,
                TaxaMultaDiariaPorcentagem = TaxaMultaDiaria * 100,
                ValorMultaJuros = Math.Round(valorMulta, 2),
                ValorTotalAtualizado = Math.Round(valorTotal, 2)
            };
        }
    }
}
