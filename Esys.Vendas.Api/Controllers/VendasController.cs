 using Esys.Vendas.Api.Dtos.Requests;
using Esys.Vendas.Domain.Interfaces.UseCase;
using Microsoft.AspNetCore.Mvc;

namespace Esys.Vendas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendasController : ControllerBase
    {
        private readonly ICriarNovoPedidoUseCase _criarNovoPedidoUseCase;
        private readonly ICancelarPedidoUseCase _cancelarPedidoUseCase;

        public VendasController(ICriarNovoPedidoUseCase useCase, ICancelarPedidoUseCase cancelarPedidoUseCase)
        {
            _criarNovoPedidoUseCase = useCase;
            _cancelarPedidoUseCase = cancelarPedidoUseCase;
        }

        [HttpGet("usuario/{id}")]
        public IActionResult GetByUser(int usuarioId)
        {
            return Ok();
        }

        [HttpGet("pedido/{id}")]
        public IActionResult GetByPedido(int pedidoId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CriarPedidoRequest pedidoRequest)
        {
            var result = await _criarNovoPedidoUseCase.Execute(pedidoRequest.ConverterParaDominio());

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return Created($"api/vendas/pedido/{result.ReturnObject?.Id}", result);
        }

        [HttpDelete("cancelar/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _cancelarPedidoUseCase.Execute(id);

            if (!result.Success)
                return BadRequest(result.ErrorMessage);

            return Ok(result.ReturnObject);
        }
    }
}
