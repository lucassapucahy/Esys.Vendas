using Esys.Vendas.Domain.DomainEntity;

namespace Esys.Vendas.Domain.Interfaces.UseCase
{
    public interface ICriarNovoPedidoUseCase
    {
        Task<ResultsDomain<Pedido>> Execute(Pedido pedido);
    }
}
