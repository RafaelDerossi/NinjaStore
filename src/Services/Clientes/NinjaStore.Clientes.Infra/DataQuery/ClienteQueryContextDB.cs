using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using NinjaStore.Core.Data;
using NinjaStore.Core.Extensions;
using NinjaStore.Core.Helpers;
using NinjaStore.Core.Mediator;
using NinjaStore.Core.Messages;
using NinjaStore.Clientes.Domain;
using NinjaStore.Clientes.Domain.FlatModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using NinjaStore.Core.ValueObjects;

namespace NinjaStore.Clientes.Infra.Data
{
    public class ClienteQueryContextDB : DbContext, IUnitOfWorks
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<ClienteFlat> ClientesFlat { get; set; }      


        public ClienteQueryContextDB(DbContextOptions<ClienteQueryContextDB> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteQueryContextDB).Assembly);

            modelBuilder.Ignore<Cliente>();
            modelBuilder.Ignore<Email>();
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
