namespace DesafioDevDotnet.DTOs.Comissao
{
    public class ComissaoVendedorResult
    {
        public string Vendedor { get; set; } = string.Empty;
        public decimal TotalVendido { get; set; }
        public decimal TotalComissao { get; set; }
    }
}
