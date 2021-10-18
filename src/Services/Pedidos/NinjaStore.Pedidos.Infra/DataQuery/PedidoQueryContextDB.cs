using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NinjaStore.Core.Data;
using NinjaStore.Core.Extensions;
using NinjaStore.Core.Helpers;
using NinjaStore.Core.Mediator;
using NinjaStore.Core.Messages;
using NinjaStore.Pedidos.Domain;
using NinjaStore.Pedidos.Domain.FlatModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaStore.Pedidos.Infra.Data
{
    public class PedidoQueryContextDB : DbContext, IUnitOfWorks
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<PedidoFlat> PedidosFlat { get; set; }

        public DbSet<ProdutoDoPedidoFlat> ProdutosFlat { get; set; }

        public PedidoQueryContextDB(DbContextOptions<PedidoQueryContextDB> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidoQueryContextDB).Assembly);

            modelBuilder.Ignore<Pedido>();
            modelBuilder.Ignore<Produto>();
        }

        public async Task<bool> Commit()
        {
            var cetZone = ZonaDeTempo.ObterZonaDeTempo();

            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataDeCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataDeCadastro").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                    entry.Property("DataDeAlteracao").CurrentValue =
                        entry.Property("DataDeCadastro").CurrentValue;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCadastro").IsModified = false;
                    entry.Property("DataDeAlteracao").CurrentValue =
                        TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);
                }
            }

            return await SaveChangesAsync() > 0;
        }
    }
}
