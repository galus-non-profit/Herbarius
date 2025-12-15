namespace Herbarius.Application.FunctionalTests;

using Microsoft.Extensions.DependencyInjection;
using Herbarius.Application;
using Herbarius.Infrastructure;

public abstract class TestBase
{

    protected ServiceProvider Provider { get; init; }

    public TestBase()
    {
        var services = new ServiceCollection();
        services.AddLogging();
        services.AddApplication();
        services.AddInfrastructure();
        this.Provider = services.BuildServiceProvider();
    }
}
