namespace DesafioDevDotnet.Models
{
    public class Produto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public int QuantidadeEstoque { get; set; }

        public Produto(int codigoProduto, string descricaoProduto, int quantidadeEstoque)
        {
            CodigoProduto = codigoProduto;
            DescricaoProduto = descricaoProduto;
            QuantidadeEstoque = quantidadeEstoque;
        }

        public void AdicionarEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public void RemoverEstoque(int quantidade)
        {
            QuantidadeEstoque -= quantidade;
        }
    }
}
