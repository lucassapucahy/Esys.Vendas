using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Esys.Vendas.Infra.Ioc.Domain
{
    public static class DomainInjection
    {
        public static IServiceCollection AddDomainDependencies(this IServiceCollection services, IConfiguration configuration) 
        {

            return services;
        }
    }
}
