using Esys.Vendas.Domain.Interfaces;
using Esys.Vendas.Infra.Data.Repositorio;
using Esys.Vendas.Infra.Message;
using Esys.Vendas.Infra.MessageBrokers.Rabbit;
using Esys.Vendas.Infra.MessageBrokers.Rabbit.Consumers.UsuarioCriado;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Esys.Vendas.Infra.Ioc.Infra
{
    public static class InfraInjection
    {
        public static IServiceCollection AddInfraDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            AddDatabases(services);

            AddInjections(services);

            AddHosteds(services);

            return services;
        }

        private static void AddDatabases(IServiceCollection services) 
        {
            services.AddDbContext<VendasContext>();
        }

        private static void AddInjections(IServiceCollection services)
        {
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<IProdutoEstoqueRepositorio, ProdutoEstoqueRepositorio>();
            services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<IUsuarioCriadoConsumer, UsuarioCriadoConsumer>();
            services.AddScoped<IRabbitUtils, RabbitUtils>();

        }

        private static void AddHosteds(IServiceCollection services)
        {
            services.AddHostedService<UsuarioCriadoService>();
        }

    }
}
