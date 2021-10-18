using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Produtos.Domain;
using NinjaStore.Produtos.Domain.FlatModel;

namespace NinjaStore.Produtos.Infra.Data.Mapping
{
   public class ProdutoFlatMapping : IEntityTypeConfiguration<ProdutoFlat>
    {
        public void Configure(EntityTypeBuilder<ProdutoFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("ProdutosFlat");

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Produto.Max})");

            builder.Property(u => u.Valor).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Estoque).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Descricao).HasColumnType($"varchar({Produto.Max})");

        }
    }
}
