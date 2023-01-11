using Esys.Vendas.Domain.DomainEntity;
using Esys.Vendas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Esys.Vendas.Infra.Data.Repositorio
{
    public class PedidoRepositorio : RepositorioBase<Pedido>, IPedidoRepositorio
    {
        private readonly VendasContext _context;
        public PedidoRepositorio(VendasContext vendasContext) : base(vendasContext)
        {
            _context = vendasContext;
        }

        public async Task<Pedido?> BuscarPorIdEagerLoad(int id)
        {
            return await _context.Set<Pedido>().Include(x => x.Produtos).Include(z => z.Usuario).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
