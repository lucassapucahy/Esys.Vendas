using Esys.Vendas.Domain.DomainEntity;
using Esys.Vendas.Domain.Interfaces;

namespace Esys.Vendas.Infra.Data.Repositorio
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(VendasContext vendasContext) : base(vendasContext)
        {
        }
    }
}
