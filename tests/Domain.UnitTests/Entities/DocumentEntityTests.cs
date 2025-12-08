namespace Herbarius.Domain.UnitTests.Entities;

using Herbarius.Domain.Entities;
using Herbarius.Domain.Exceptions;

[TestClass]
public sealed class DocumentEntityTests
{
    [TestMethod]
    public void TestMethod1()
    {
        // Arrange
        var id = Guid.NewGuid();
        var documentId = new DocumentId(id);
        var name = "name";

        // Act
        var document = new DocumentEntity(documentId, name);

        // Assert
        document.Id.ShouldBe(documentId)
            ;

        document.Id.Value.ShouldNotBe(Guid.Empty)
            ;
        document.Id.Value.ShouldBe(id)
            ;

        document.Name.ShouldBe(name)
            ;
    }

    [TestMethod]
    public void TestMethod2()
    {
        // Arrange
        var id = Guid.Empty;

        // Act
        var sut = () => { _ = new DocumentId(id); };

        // Assert
        sut.ShouldThrow<EmptyIdException>()
            .Message
            .ShouldBe("DocumentId cannot be empty.")
            ;
    }
}
