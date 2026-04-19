using HabitManager.Entities;
using HabitManager.Entities.Habit;
using MongoDB.Driver;

namespace HabitManager.Database;

public class HabitManagerDbContext
{
    private readonly IMongoDatabase _database;
    public HabitManagerDbContext(IMongoClient client,IConfiguration configuration)
    {
        var databaseName = configuration.GetSection("Database:Name").Value;
        _database = client.GetDatabase(databaseName);
    }
    public IMongoCollection<Habit> Habits =>
        _database.GetCollection<Habit>("Habits");
}