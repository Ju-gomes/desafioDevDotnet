using DesafioDevDotnet.DTOs.Comissao;
using DesafioDevDotnet.Services.Interfaces;

namespace DesafioDevDotnet.Services
{
    public class ComissaoService : IComissaoService
    {
        private const decimal LimiteSemComissao = 100m;
        private const decimal LimiteComissaoBaixa = 500m;
        private const decimal PercentualBaixo = 0.01m;
        private const decimal PercentualAlto = 0.05m;

        public decimal CalcularComissao(decimal valor)
        {
            if (valor < LimiteSemComissao) return 0m; // Vendas abaixo de R$100 não geram comissão[cite: 1]
            if (valor < LimiteComissaoBaixa) return valor * PercentualBaixo; // Vendas abaixo de R$500 geram 1%[cite: 1]

            return valor * PercentualAlto; // A partir de R$500 gera 5%[cite: 1]
        }

        public Dictionary<string, decimal> CalcularPorVendedor(IEnumerable<VendaItemDto> vendas)
            => vendas
                .GroupBy(v => v.Vendedor)
                .ToDictionary(g => g.Key, g => g.Sum(v => CalcularComissao(v.Valor)));

        public List<ComissaoVendedorResult> CalcularComissoes(ProcessarVendasRequest request)
        {
            if (request?.Vendas == null || !request.Vendas.Any())
                return new List<ComissaoVendedorResult>();

            return request.Vendas
                .GroupBy(v => v.Vendedor)
                .Select(g => new ComissaoVendedorResult
                {
                    Vendedor = g.Key,
                    TotalVendido = g.Sum(v => v.Valor),
                    TotalComissao = g.Sum(v => CalcularComissao(v.Valor))
                })
                .ToList();
        }
    }
}