namespace Herbarius.Application.UnitTests.Documents.CommandHandlers;

using Herbarius.Application.Documents.CommandHandlers;
using Herbarius.Application.Documents.Commands;
using Herbarius.Domain.Entities;
using Herbarius.Domain.Interfaces;
using NSubstitute.ReceivedExtensions;

[TestClass]
public sealed class CreateDocumentHandlerTests
{
    [TestMethod]
    public async Task TestMethod1()
    {
        IDocumentRepository repository = Substitute.For<IDocumentRepository>();
        var command = new CreateDocument
        {
            Id = new DocumentId(Guid.NewGuid()),
            Name = "testowa",
        }
        ;

        var handler = new CreateDocumentHandler(repository);

        await handler.Handle(command, CancellationToken.None);

        await repository.Received().SaveAsync(Arg.Is<DocumentEntity>(e => e.Id == command.Id && e.Name == command.Name));
    }
}
