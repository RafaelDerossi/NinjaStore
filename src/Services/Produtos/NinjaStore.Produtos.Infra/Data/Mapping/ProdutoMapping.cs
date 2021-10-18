using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Produtos.Domain;

namespace NinjaStore.Produtos.Infra.Data.Mapping
{
   public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Produtos");

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Produto.Max})");

            builder.Property(u => u.Valor).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Estoque).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Descricao).HasColumnType($"varchar({Produto.Max})");

        }
    }
}
