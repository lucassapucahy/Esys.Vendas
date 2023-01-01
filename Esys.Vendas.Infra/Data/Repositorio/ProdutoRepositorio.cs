using Esys.Vendas.Domain.DomainEntity;
using Esys.Vendas.Domain.Interfaces;

namespace Esys.Vendas.Infra.Data.Repositorio
{
    public class ProdutoRepositorio : RepositorioBase<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(VendasContext vendasContext) : base(vendasContext)
        {
        }
    }
}
