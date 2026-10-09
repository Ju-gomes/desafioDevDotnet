using DesafioDevDotnet.DTOs.Comissao;

namespace DesafioDevDotnet.Services.Interfaces
{
    public interface IComissaoService
    {
        decimal CalcularComissao(decimal valor);
        Dictionary<string, decimal> CalcularPorVendedor(IEnumerable<VendaItemDto> vendas);
        List<ComissaoVendedorResult> CalcularComissoes(ProcessarVendasRequest request);
    }
}