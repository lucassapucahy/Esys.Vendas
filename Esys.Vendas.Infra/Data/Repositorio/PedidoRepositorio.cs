using Esys.Vendas.Domain.DomainEntity;
using Esys.Vendas.Domain.Interfaces;

namespace Esys.Vendas.Infra.Data.Repositorio
{
    public class PedidoRepositorio : RepositorioBase<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(VendasContext vendasContext) : base(vendasContext)
        {
        }
    }
}
