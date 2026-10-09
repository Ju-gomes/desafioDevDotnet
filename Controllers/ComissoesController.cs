using DesafioDevDotnet.DTOs.Comissao;
using DesafioDevDotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDevDotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComissoesController : ControllerBase
    {
        private readonly IComissaoService _comissaoService;

        public ComissoesController(IComissaoService comissaoService)
        {
            _comissaoService = comissaoService;
        }

        [HttpPost("calcular")]
        public IActionResult CalcularComissoes([FromBody] ProcessarVendasRequest request)
        {
            if (request?.Vendas == null || !request.Vendas.Any())
                return BadRequest("A lista de vendas não pode estar vazia.");

            var resultado = _comissaoService.CalcularComissoes(request);
            return Ok(resultado);
        }
    }
}
