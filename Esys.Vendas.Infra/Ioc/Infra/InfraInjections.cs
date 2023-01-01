using Esys.Vendas.Domain.Interfaces;
using Esys.Vendas.Infra.Data.Repositorio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Esys.Vendas.Infra.Ioc.Infra
{
    public static class DomainInjection
    {
        public static IServiceCollection AddInfraDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<VendasContext>();

            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<IProdutoEstoqueRepositorio, ProdutoEstoqueRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();

            return services;
        }
    }
}
