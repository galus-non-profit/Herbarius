namespace Herbarius.Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Herbarius.Domain.Interfaces;
using Herbarius.Domain.Entities;

public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(assembly);
            });

        services.AddSingleton<IDocumentRepository, DocumentRepository>();

        return services;
    }
}


internal sealed class DocumentRepository : IDocumentRepository
{
    private readonly Dictionary<DocumentId, DocumentEntity> entities = new();
    public async Task<DocumentEntity?> LoadAsync(DocumentId id, CancellationToken cancellationToken = default)
    {
        return entities[id];
    }

    public async Task SaveAsync(DocumentEntity entity, CancellationToken cancellationToken = default)
    {
        entities[entity.Id] = entity;
    }
}

