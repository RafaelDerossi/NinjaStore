using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Clientes.Domain;
using NinjaStore.Clientes.Domain.FlatModel;
using NinjaStore.Core.ValueObjects;

namespace NinjaStore.Clientes.Infra.Data.Mapping
{
   public class ClienteFlatMapping : IEntityTypeConfiguration<ClienteFlat>
    {
        public void Configure(EntityTypeBuilder<ClienteFlat> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("ClientesFlat");

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({Cliente.Max})");

            builder.Property(u => u.Email).IsRequired().HasColumnType($"varchar({Email.EmailMaximo})");

            builder.Property(u => u.Aldeia).IsRequired().HasColumnType($"varchar({Cliente.Max})");

        }
    }
}
