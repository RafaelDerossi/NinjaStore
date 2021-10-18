using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NinjaStore.Core.DomainObjects;
using NinjaStore.Core.Mediator;
using Microsoft.EntityFrameworkCore;

namespace NinjaStore.Core.Extensions
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());


            foreach (var item in domainEvents)
            {
                await mediator.PublicarEvento(item);
                Thread.Sleep(500);
            }
            //var tasks = domainEvents
            //    .Select(async (domainEvent) =>
            //    {
            //        await mediator.PublicarEvento(domainEvent);                    
            //    });

            //await Task.WhenAll(tasks);
        }
    }
}
