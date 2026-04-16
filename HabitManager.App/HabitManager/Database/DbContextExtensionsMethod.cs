using MongoDB.Driver;

namespace HabitManager.Database;

public static class DbContextExtensionsMethod
{
    public static IServiceCollection AddHabitManagerDbContext(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("Database:Url").Value;
        services.AddSingleton<IMongoClient>(_ => new MongoClient(connectionString));
        services.AddSingleton<HabitManagerDbContext>();
        return services;
    }
}