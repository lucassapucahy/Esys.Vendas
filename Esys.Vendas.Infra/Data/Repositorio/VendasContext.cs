using Esys.Vendas.Infra.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Esys.Vendas.Infra.Data.Repositorio
{
    public class VendasContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public VendasContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("VendasDB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoEntityDbConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioEntityDbConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoEstoqueEntityDbConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoEntityDbConfiguration());

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {

                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

        }

    }

  
}
