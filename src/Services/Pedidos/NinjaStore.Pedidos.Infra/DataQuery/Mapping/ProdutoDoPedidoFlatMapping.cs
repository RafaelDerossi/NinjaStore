using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Pedidos.Domain;
using NinjaStore.Pedidos.Domain.FlatModel;

namespace NinjaStore.Pedidos.Infra.Data.Mapping
{
   public class ProdutoDoPedidoFlatMapping : IEntityTypeConfiguration<ProdutoDoPedidoFlat>
    {
        public void Configure(EntityTypeBuilder<ProdutoDoPedidoFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("ProdutosDoPedidoFlat");

            builder.Property(u => u.Descricao).IsRequired().HasColumnType($"varchar({Pedido.Max})");

            builder.Property(u => u.Descricao).HasColumnType($"varchar({Pedido.Max})");

            builder.Property(u => u.Valor).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Quantidade).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Desconto).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.ValorTotal).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.PedidoFlatId).IsRequired();
        }
    }
}
