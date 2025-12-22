using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Herbarius.Infrastructure.MongoDB.Models;

internal sealed class DocumentDbEntity
{
    [BsonId]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
