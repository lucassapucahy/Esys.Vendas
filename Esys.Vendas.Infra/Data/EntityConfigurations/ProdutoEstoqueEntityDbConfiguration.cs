using Esys.Vendas.Domain.DomainEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Esys.Vendas.Infra.Data.EntityConfigurations
{
    public class ProdutoEstoqueEntityDbConfiguration : IEntityTypeConfiguration<ProdutoEstoque>
    {
        public void Configure(EntityTypeBuilder<ProdutoEstoque> builder)
        {
            builder.ToTable("ProdutosEstoques");

            builder.HasKey("Id");
        }
    }
}
