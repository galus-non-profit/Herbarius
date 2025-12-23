namespace Herbarius.Infrastructure.MongoDB.Services;

using Herbarius.Domain.Interfaces;
using Herbarius.Domain.Entities;
using Herbarius.Infrastructure.MongoDB.Models;
using global::MongoDB.Driver;

internal sealed class DocumentRepository(IMongoDatabase database) : IDocumentRepository
{
    private const string COLLECTION_NAME = "Docs";

    public async Task<DocumentEntity?> LoadAsync(DocumentId id, CancellationToken cancellationToken = default)
    {
        var collection = database.GetCollection<DocumentDbEntity>(COLLECTION_NAME);

        var filter = Builders<DocumentDbEntity>.Filter.Eq("Id", $"{id.Value}");
        var dbEntity = await collection.Find(filter).FirstOrDefaultAsync();

        if (dbEntity is null)
        {
            return default;
        }

        var entity = new DocumentEntity(new DocumentId(dbEntity.Id), dbEntity.Name);

        return entity;
    }

    public async Task SaveAsync(DocumentEntity entity, CancellationToken cancellationToken = default)
    {
        var collection = database.GetCollection<DocumentDbEntity>(COLLECTION_NAME);

        var filter = Builders<DocumentDbEntity>.Filter.Eq(nameof(entity.Id), $"{entity.Id.Value}");

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
