using Esys.Vendas.Domain.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esys.Vendas.Infra.Data.EntityConfigurations
{
    public class UsuarioEntityDbConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey("Id");

            builder.HasMany(x => x.Pedidos);
        }
    }
}
