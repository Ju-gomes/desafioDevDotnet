namespace DesafioDevDotnet.DTOs.Estoque
{
    public class ProdutoDto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public int QuantidadeEstoque { get; set; }
    }
}
