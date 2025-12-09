namespace Herbarius.Application.Documents.Commands;

public sealed record class CreateDocument : IRequest
{
    public required DocumentId Id { get; init; }
    public required string Name { get; init; }
}
