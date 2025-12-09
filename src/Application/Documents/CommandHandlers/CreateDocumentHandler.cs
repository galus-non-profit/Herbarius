namespace Herbarius.Application.Documents.CommandHandlers;

using Commands;
using Domain.Interfaces;
using Herbarius.Domain.Entities;

internal sealed class CreateDocumentHandler(IDocumentRepository repository) : IRequestHandler<CreateDocument>
{
    public async Task Handle(CreateDocument request, CancellationToken cancellationToken)
    {
        var entity = new DocumentEntity(request.Id, request.Name);
        await repository.SaveAsync(entity, cancellationToken);
    }
}
