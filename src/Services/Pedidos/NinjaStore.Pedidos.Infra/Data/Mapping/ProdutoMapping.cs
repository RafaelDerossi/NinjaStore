using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Pedidos.Domain;

namespace NinjaStore.Pedidos.Infra.Data.Mapping
{
   public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("ProdutosDoPedido");

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Produto.Max})");

            builder.Property(u => u.Foto).HasColumnType($"varchar({Produto.Max})");

            builder.Property(u => u.Valor).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Quantidade).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Desconto).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.ValorTotal).IsRequired().HasColumnType($"decimal(14,2)");            

            builder.Property(u => u.PedidoId).IsRequired();
        }
    }
}
