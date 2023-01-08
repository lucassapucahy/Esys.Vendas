using Esys.Vendas.Domain.DomainEntity;
using Esys.Vendas.Domain.Enum;
using Esys.Vendas.Domain.Interfaces;
using Esys.Vendas.Domain.Interfaces.UseCase;
using Microsoft.Extensions.Logging;

namespace Esys.Vendas.Domain.UseCases
{
    public class CancelarPedidoUseCase : ICancelarPedidoUseCase
    {
        private readonly ILogger<CancelarPedidoUseCase> _logger;
        private readonly IPedidoRepositorio _pedidoRepositorio;

        public CancelarPedidoUseCase(ILogger<CancelarPedidoUseCase> logger, IPedidoRepositorio pedidoRepositorio)
        {
            _logger = logger;
            _pedidoRepositorio = pedidoRepositorio;
        }

        public async Task<ResultsDomain<Pedido>> Execute(int pedidoId)
        {
            var pedido = await _pedidoRepositorio.Buscar(pedidoId);

            if (pedido == null)
            {
                _logger.LogError("Pedido não encontrado.");
                return ResultsDomain<Pedido>.ResultsDomainErroBuilder("Pedido não encontrado.");
            }

            if (pedido.StatusPedido != StatusPedidoEnum.Analise)
            {
                _logger.LogError("Pedido em um status impossivel de cancelar.");
                return ResultsDomain<Pedido>.ResultsDomainErroBuilder("Pedido em um status impossivel de cancelar.");
            }

            pedido.AlterarParaCancelado();
            var pedidoResult = await _pedidoRepositorio.Alterar(pedido);
            await _pedidoRepositorio.SalvarAlteracoes();

            return ResultsDomain<Pedido>.ResultsDomainSuccessBuilder(pedidoResult);
        }
    }
}
