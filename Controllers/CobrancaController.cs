using DesafioDevDotnet.DTOs.Cobranca;
using DesafioDevDotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDevDotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CobrancaController : ControllerBase
    {
        private readonly ICobrancaService _cobrancaService;

        public CobrancaController(ICobrancaService cobrancaService)
        {
            _cobrancaService = cobrancaService;
        }

        [HttpPost("calcular-juros")]
        public IActionResult CalcularJuros([FromBody] CalculoJurosRequest request)
        {
            if (request.ValorOriginal <= 0)
                return BadRequest("O valor original deve ser maior que zero.");

            var resultado = _cobrancaService.CalcularJuros(request);
            return Ok(resultado);
        }
    }
}
