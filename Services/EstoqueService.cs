using DesafioDevDotnet.DTOs.Estoque;
using DesafioDevDotnet.Enums;
using DesafioDevDotnet.Models;
using DesafioDevDotnet.Services.Interfaces;
using System.Collections.Concurrent;

namespace DesafioDevDotnet.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly ConcurrentDictionary<int, Produto> _produtos = new();

        public EstoqueService()
        {
            // Carga inicial conforme o JSON fornecido[cite: 1]
            SeedData();
        }

        private void SeedData()
        {
            var itens = new List<Produto>
            {
                new(101, "Caneta Azul", 150),
                new(102, "Caderno Universitário", 75),
                new(103, "Borracha Branca", 200),
                new(104, "Lápis Preto HB", 320),
                new(105, "Marcador de Texto Amarelo", 90)
            };

            foreach (var item in itens)
            {
                _produtos.TryAdd(item.CodigoProduto, item);
            }
        }

        public List<ProdutoDto> ObterTodos()
        {
            return _produtos.Values.Select(p => new ProdutoDto
            {
                CodigoProduto = p.CodigoProduto,
                DescricaoProduto = p.DescricaoProduto,
                QuantidadeEstoque = p.QuantidadeEstoque
            }).ToList();
        }

        public MovimentacaoResponse ProcessarMovimentacao(MovimentacaoRequest request)
        {
            if (!_produtos.TryGetValue(request.CodigoProduto, out var produto))
                throw new KeyNotFoundException($"Produto com código {request.CodigoProduto} não encontrado.");

            if (request.Quantidade <= 0)
                throw new ArgumentException("A quantidade movimentada deve ser maior que zero.");

            if (request.Tipo == TipoMovimentacao.Saida && produto.QuantidadeEstoque < request.Quantidade)
                throw new InvalidOperationException($"Estoque insuficiente. Saldo disponível: {produto.QuantidadeEstoque}");

            if (request.Tipo == TipoMovimentacao.Entrada)
                produto.AdicionarEstoque(request.Quantidade);
            else
                produto.RemoverEstoque(request.Quantidade);

            return new MovimentacaoResponse
            {
                IdMovimentacao = Guid.NewGuid(),
                CodigoProduto = produto.CodigoProduto,
                DescricaoProduto = produto.DescricaoProduto,
                DescricaoMovimentacao = request.DescricaoMovimentacao,
                EstoqueFinal = produto.QuantidadeEstoque
            };
        }
    }
}
