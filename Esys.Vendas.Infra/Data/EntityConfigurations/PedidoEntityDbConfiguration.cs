using Esys.Vendas.Domain.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esys.Vendas.Infra.Data.EntityConfigurations
{
    public class PedidoEntityDbConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey("Id");

            builder.HasMany(x => x.Produtos);

            builder.HasOne(x => x.Usuario);

        }
    }
}
