namespace Herbarius.Application.FunctionalTests.Documents;

using Herbarius.Application.Documents.Commands;
using Herbarius.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;



[TestClass]
public sealed class CreateDocumentTests : TestBase
{
    [TestMethod]
    public async Task TestMethod1()
    {
        var command = new CreateDocument
        {
            Id = new DocumentId(Guid.NewGuid()),
            Name = "testowa",
        }
      ;
        var mediator = this.Provider.GetRequiredService<IMediator>();
        await mediator.Send(command);

        var repository = this.Provider.GetRequiredService<IDocumentRepository>();
        var entity = await repository.LoadAsync(command.Id);

        entity.ShouldNotBeNull();
        entity.Id.ShouldBe(command.Id);
        entity.Name.ShouldBe(command.Name);
    }
}