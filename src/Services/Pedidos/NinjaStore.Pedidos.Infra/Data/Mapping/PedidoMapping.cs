using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Pedidos.Domain;

namespace NinjaStore.Pedidos.Infra.Data.Mapping
{
   public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Pedidos");

            builder.Property(u => u.Numero).IsRequired().ValueGeneratedOnAdd();

            builder.Property(u => u.JustificativaDoCancelamento).HasColumnType($"varchar({Pedido.Max})");

            builder.Property(u => u.ClienteId).IsRequired();
        }
    }
}
