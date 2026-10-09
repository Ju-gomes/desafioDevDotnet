namespace DesafioDevDotnet.DTOs.Comissao
{
    public class ProcessarVendasRequest
    {
        public List<VendaItemDto> Vendas { get; set; } = new();
    }
}
