using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace React.MongoDB.Models;

public class Project
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = null;
    public virtual List<Tag>? Tags { get; set; } = null;
    public virtual List<Ticket> Tickets { get; set; }
}
