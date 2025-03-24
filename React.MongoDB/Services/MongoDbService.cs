using Microsoft.Extensions.Options;
using MongoDB.Driver;
using React.MongoDB.Models;
using Tag = React.MongoDB.Models.Tag;

namespace React.MongoDB.Services;

public class MongoDbService
{
    private readonly IMongoDatabase _database;
    
    public MongoDbService(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Project> Projects => _database.GetCollection<Project>("Projects");
    public IMongoCollection<Tag> Tags => _database.GetCollection<Tag>("Tags");
    public IMongoCollection<Ticket> Tickets => _database.GetCollection<Ticket>("Tickets");
    public IMongoCollection<Status> Statuses => _database.GetCollection<Status>("Statuses");
}


