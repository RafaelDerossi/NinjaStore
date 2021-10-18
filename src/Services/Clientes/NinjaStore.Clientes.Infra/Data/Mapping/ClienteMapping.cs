using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NinjaStore.Clientes.Domain;
using NinjaStore.Core.ValueObjects;

namespace NinjaStore.Clientes.Infra.Data.Mapping
{
   public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(u => u.Id);

            builder.ToTable("Clientes");

            builder.Property(u => u.Nome).IsRequired().HasColumnType($"varchar({Cliente.Max})");

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(u => u.Endereco).IsRequired()
                    .HasMaxLength(Email.EmailMaximo)
                    .HasColumnName("Email")
                    .HasColumnType($"varchar({Email.EmailMaximo})");
            });

            builder.Property(u => u.Aldeia).IsRequired().HasColumnType($"varchar({Cliente.Max})");

        }
    }
}
