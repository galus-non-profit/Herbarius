namespace Herbarius.Infrastructure.MongoDB;

using Microsoft.Extensions.DependencyInjection;
using Herbarius.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Herbarius.Infrastructure.MongoDB.Services;
using global::MongoDB.Driver;

internal static class ServiceExtensions
{
    public static IServiceCollection AddMongoDB(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var mongoUrl = new MongoUrl(connectionString);
        var databaseName = mongoUrl.DatabaseName;

        var client = new MongoClient(connectionString);
        var database = client.GetDatabase(databaseName);

        services.AddSingleton<IMongoDatabase>(database);
        services.AddSingleton<IDocumentRepository, DocumentRepository>();

        return services;
    }
}
