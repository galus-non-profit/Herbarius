namespace Herbarius.Application.FunctionalTests;

using Microsoft.Extensions.DependencyInjection;
using Herbarius.Application;
using Herbarius.Infrastructure;
using Microsoft.Extensions.Configuration;

public abstract class TestBase
{
    protected ServiceProvider Provider { get; init; }

    public TestBase()
    {
        var collation = new Dictionary<string, string?>
        {
            {"ConnectionStrings:DefaultConnection", "mongodb://localhost:27017/Herbarius"},
        };
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(collation)
            .Build();
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddApplication();
        services.AddInfrastructure(configuration);
        this.Provider = services.BuildServiceProvider();

        //TODO: dodać testcontainers
    }
}
