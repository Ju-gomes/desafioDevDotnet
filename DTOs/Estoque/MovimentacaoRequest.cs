using DesafioDevDotnet.Enums;

namespace DesafioDevDotnet.DTOs.Estoque
{
    public class MovimentacaoRequest
    {
        public int CodigoProduto { get; set; }
        public string DescricaoMovimentacao { get; set; } = string.Empty; // Descrição para identificar a movimentação[cite: 1]
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
    }
}
