using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Core.ValueObjects;
using NinjaStore.Pedidos.Domain;
using NinjaStore.Pedidos.Domain.FlatModel;

namespace NinjaStore.Pedidos.Infra.Data.Mapping
{
   public class PedidoFlatMapping : IEntityTypeConfiguration<PedidoFlat>
    {
        public void Configure(EntityTypeBuilder<PedidoFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("PedidosFlat");

            builder.Property(u => u.Numero).IsRequired();

            builder.Property(u => u.JustificativaDoCancelamento).HasColumnType($"varchar({Pedido.Max})");

            builder.Property(u => u.Valor).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.Desconto).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.ValorTotal).IsRequired().HasColumnType($"decimal(14,2)");

            builder.Property(u => u.ClienteId).IsRequired();

            builder.Property(u => u.NomeDoCliente).IsRequired().HasColumnType($"varchar({Pedido.Max})");

            builder.Property(u => u.EmailDoCliente).IsRequired().HasColumnType($"varchar({Email.EmailMaximo})");            

            builder.Property(u => u.AldeiaDoCliente).IsRequired().HasColumnType($"varchar({Pedido.Max})");

        }
    }
}
