using Esys.Vendas.Domain.Interfaces.UseCase;
using Esys.Vendas.Domain.UseCases;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Esys.Vendas.Infra.Ioc.Domain
{
    public static class DomainInjection
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<ICriarNovoPedidoUseCase, CriarNovoPedidoUseCase>();
            services.AddScoped<ICancelarPedidoUseCase, CancelarPedidoUseCase>();
            return services;
        }
    }
}
