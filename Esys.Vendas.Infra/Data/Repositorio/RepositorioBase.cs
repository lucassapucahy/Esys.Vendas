using Esys.Vendas.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Esys.Vendas.Infra.Data.Repositorio
{
    public class RepositorioBase<T> : IRepositorioBase<T> , IDisposable where T : class
    {
        private VendasContext _context;
        private DbSet<T> _dbSet { get; set; }
        public RepositorioBase(VendasContext vendasContext)
        {
            _context = vendasContext;
            _dbSet = vendasContext.Set<T>();
        }

        public async Task<T> Adicionar(T item)
        {
            var result = await _dbSet.AddAsync(item);
            return result.Entity;
        }

        public Task<T> Alterar(T item)
        {
            var result = _dbSet.Update(item);
            return Task.FromResult(result.Entity);
        }

        public async Task<T?> Buscar(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> BuscarTodos()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Excluir(int id)
        {
            var itemParaExcluir = await Buscar(id);

            if (itemParaExcluir != null)
                _dbSet.Remove(itemParaExcluir);
        }

        public async Task SalvarAlteracoes()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
