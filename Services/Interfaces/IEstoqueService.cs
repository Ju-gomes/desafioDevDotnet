using DesafioDevDotnet.DTOs.Estoque;

namespace DesafioDevDotnet.Services.Interfaces
{
    public interface IEstoqueService
    {
        List<ProdutoDto> ObterTodos();
        MovimentacaoResponse ProcessarMovimentacao(MovimentacaoRequest request);
    }
}
