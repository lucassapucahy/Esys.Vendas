using Esys.Vendas.Domain.DomainEntity;

namespace Esys.Vendas.Domain.Interfaces
{
    public interface IPedidoRepositorio:IRepositorioBase<Pedido>
    {
        public Task<Pedido?> BuscarPorIdEagerLoad(int id);
    }
}
