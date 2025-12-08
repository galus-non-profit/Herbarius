namespace Herbarius.Domain.Exceptions;

public sealed class EmptyIdException : DomainException
{
    public EmptyIdException() : base("DocumentId cannot be empty.")
    {
    }
}
