using Esys.Vendas.Domain.DomainEntity;

namespace Esys.Vendas.Domain.Interfaces.UseCase
{
    public interface ICancelarPedidoUseCase
    {
        Task<ResultsDomain<Pedido>> Execute(int pedidoId);
    }
}
