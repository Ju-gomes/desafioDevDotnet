namespace DesafioDevDotnet.DTOs.Estoque
{
    public class MovimentacaoResponse
    {
        public Guid IdMovimentacao { get; set; } // Identificador único[cite: 1]
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; } = string.Empty;
        public string DescricaoMovimentacao { get; set; } = string.Empty;
        public int EstoqueFinal { get; set; } // Quantidade final do estoque[cite: 1]
    }
}
