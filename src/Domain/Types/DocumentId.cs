namespace Herbarius.Domain.Types;

using Herbarius.Domain.Exceptions;

public readonly record struct DocumentId
{
    public Guid Value { get; private init; }

    public DocumentId(Guid value)
    {
        if (Guid.Empty == value)
        {
            throw new EmptyIdException();
        }

        this.Value = value;
    }
}
