 using Esys.Vendas.Api.Dtos.Requests;
using Esys.Vendas.Api.Dtos.Responses;
using Esys.Vendas.Domain.Interfaces;
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
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IConfiguration _config;

        public VendasController(ICriarNovoPedidoUseCase useCase, ICancelarPedidoUseCase cancelarPedidoUseCase, IPedidoRepositorio pedidoRepositorio, IConfiguration config)
        {
            _criarNovoPedidoUseCase = useCase;
            _cancelarPedidoUseCase = cancelarPedidoUseCase;
            _pedidoRepositorio = pedidoRepositorio;
            _config = config;
        }

        [HttpGet("usuario/{id}")]
        public IActionResult GetByUser(int usuarioId)
        {
            var teste = _config.GetConnectionString("VendasMongoDb");
            return Ok(teste);
        }

        [HttpGet("pedido/{id}")]
        public async Task<IActionResult> GetByPedido(int id)
        {
            var pedido = await _pedidoRepositorio.BuscarPorIdEagerLoad(id);

            if (pedido == null)
                return NotFound();

            return Ok(PedidoResponse.CriarApartirDominio(pedido));
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
