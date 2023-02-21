using Esys.Vendas.Infra.Data.Repositorio;
using Esys.Vendas.Infra.MessageBrokers.Rabbit;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Esys.Vendas.Infra.Ioc
{
    public static class AppExtensions
    {
        public static IApplicationBuilder RunEntityMigrations(this IApplicationBuilder app) 
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<VendasContext>();
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
            }

            return app;
        }

        public static IApplicationBuilder RunRabbitStartup(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var rabbitUtils = services.GetRequiredService<IRabbitUtils>();
                rabbitUtils.Startup();
            }

            return app;
        }
    }
}
