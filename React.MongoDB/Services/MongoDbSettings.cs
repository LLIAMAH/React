namespace React.MongoDB.Services;

public class MongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public string ProjectsCollection { get; set; } = string.Empty;
    public string TagsCollection { get; set; } = string.Empty;
    public string TicketsCollection { get; set; } = string.Empty;
    public string StatusesCollection { get; set; } = string.Empty;
}
