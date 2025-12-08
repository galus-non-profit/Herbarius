namespace Herbarius.Domain.Interfaces;

using Herbarius.Domain.Entities;

public interface IDocumentRepository
{
    Task<DocumentEntity?> LoadAsync(DocumentId id, CancellationToken cancellationToken = default);
    Task SaveAsync(DocumentEntity entity, CancellationToken cancellationToken = default);
}
