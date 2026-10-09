using DesafioDevDotnet.DTOs.Estoque;
using DesafioDevDotnet.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDevDotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _estoqueService;

        public EstoqueController(IEstoqueService estoqueService)
        {
            _estoqueService = estoqueService;
        }

        [HttpGet]
        public IActionResult ObterEstoqueAtual()
        {
            return Ok(_estoqueService.ObterTodos());
        }

        [HttpPost("movimentar")]
        public IActionResult MovimentarEstoque([FromBody] MovimentacaoRequest request)
        {
            try
            {
                var response = _estoqueService.ProcessarMovimentacao(request);
                return Ok(response);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
