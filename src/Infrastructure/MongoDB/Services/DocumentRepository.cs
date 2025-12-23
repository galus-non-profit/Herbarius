namespace Herbarius.Infrastructure.MongoDB.Services;

using Herbarius.Domain.Interfaces;
using Herbarius.Domain.Entities;
using global::MongoDB.Driver;
using Herbarius.Infrastructure.MongoDB.Models;

internal sealed class DocumentRepository(IMongoDatabase database) : IDocumentRepository
{
    public Task<DocumentEntity?> LoadAsync(DocumentId id, CancellationToken cancellationToken = default)
    {
        var collection = database.GetCollection<DocumentDbEntity>("Docs");
        var filter = Builders<DocumentDbEntity>.Filter.Eq("Id", id.Value.ToString());
        var dbEntity = collection.Find(filter).First();
        var entity = new DocumentEntity(new DocumentId(dbEntity.Id), dbEntity.Name);

        return Task.FromResult<DocumentEntity?>(entity);
    }

    public async Task SaveAsync(DocumentEntity entity, CancellationToken cancellationToken = default)
    {
        var collection = database.GetCollection<DocumentDbEntity>("Docs");

        var filter = Builders<DocumentDbEntity>.Filter.Eq("Id", entity.Id.Value.ToString());

        var dbEntity = new DocumentDbEntity
        {
            Id = entity.Id.Value,
            Name = entity.Name,
        };

        var options = new ReplaceOptions
        {
            IsUpsert = true,
        };

        await collection.ReplaceOneAsync(filter, dbEntity, options, cancellationToken);
    }
}
