
namespace Herbarius.Infrastructure.MongoDB.Services;

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Herbarius.Domain.Interfaces;
using Herbarius.Domain.Entities;
using Microsoft.Extensions.Configuration;
using global::MongoDB.Driver;
using Herbarius.Infrastructure.MongoDB.Models;

internal sealed class DocumentRepository(IMongoDatabase database) : IDocumentRepository
{
    public Task<DocumentEntity?> LoadAsync(DocumentId id, CancellationToken cancellationToken = default)
    {
        var collection = database.GetCollection<DocumentDbEntity>("Docs");
        var filter = Builders<DocumentDbEntity>.Filter.Eq("Id", id.Value.ToString());
        var document = collection.Find(filter).First();
        var entity = new DocumentEntity(new DocumentId(document.Id), document.Name);
        return Task.FromResult<DocumentEntity?>(entity);
    }

    public async Task SaveAsync(DocumentEntity entity, CancellationToken cancellationToken = default)
    {
        var collection = database.GetCollection<DocumentDbEntity>("Docs");
        var doc = new DocumentDbEntity
        {
            Id = entity.Id.Value,
            Name = entity.Name,
        };

        var options = new ReplaceOptions { IsUpsert = true };

        await collection.InsertOneAsync(doc, new InsertOneOptions(), cancellationToken);
    }
}
