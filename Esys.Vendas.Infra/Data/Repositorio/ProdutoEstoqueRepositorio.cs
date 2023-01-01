using Esys.Vendas.Domain.DomainEntity;
using Esys.Vendas.Domain.Interfaces;

namespace Esys.Vendas.Infra.Data.Repositorio
{
    public class ProdutoEstoqueRepositorio : RepositorioBase<ProdutoEstoque>, IProdutoEstoqueRepositorio
    {
        public ProdutoEstoqueRepositorio(VendasContext vendasContext) : base(vendasContext)
        {
        }
    }
}
