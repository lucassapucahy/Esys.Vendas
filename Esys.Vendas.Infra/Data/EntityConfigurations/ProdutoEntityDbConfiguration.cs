using Esys.Vendas.Domain.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esys.Vendas.Infra.Data.EntityConfigurations
{
    public class ProdutoEntityDbConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey("Id");

            builder.HasOne(x => x.Pedido);
        }
    }
}
