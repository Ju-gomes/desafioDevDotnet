using DesafioDevDotnet.DTOs.Cobranca;

namespace DesafioDevDotnet.Services.Interfaces
{
    public interface ICobrancaService
    {
        CalculoJurosResponse CalcularJuros(CalculoJurosRequest request);
    }
}
