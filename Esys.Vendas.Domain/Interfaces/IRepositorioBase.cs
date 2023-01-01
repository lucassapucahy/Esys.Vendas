namespace Esys.Vendas.Domain.Interfaces
{
    public interface IRepositorioBase<T>
    {
        Task<T?> Buscar(int id);
        Task<List<T>> BuscarTodos();
        Task<T> Adicionar(T item);
        Task<T> Alterar(T item);
        Task Excluir(int id);
        Task SalvarAlteracoes();
    }
}
