namespace Herbarius.Domain.Entities;

public sealed class DocumentEntity
{
    public DocumentId Id { get; private init; }
    public string Name { get; private set; } = string.Empty;

    public DocumentEntity(DocumentId id, string name)
    {
        this.Id = id;
        this.SetName(name);
    }

    private void SetName(string name)
    {
        var trimmedName = name.Trim();

        if (string.IsNullOrWhiteSpace(trimmedName))
        {
            throw new ArgumentException("Name cannot be empty or whitespace.", nameof(name));
        }

        this.Name = trimmedName;
    }
}
