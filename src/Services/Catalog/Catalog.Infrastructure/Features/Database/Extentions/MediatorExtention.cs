using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Infrastructure.Features.Database.Extentions;
public static class MediatorExtension
{
    public static async Task DispatchDomainEventsAsync(
        this IMediator mediator,
        CatalogContext context)
    {
        var domainEntities = context.ChangeTracker
            .Entries<Entity>()
            .Where(x =>
                x.Entity.DomainEvents != null &&
                x.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
            .ToList();

        // Clear Domain Events
        domainEntities.ForEach(
            entity => entity.Entity.ClearDomainEvents());

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(
                domainEvent);
        }
    }
}

