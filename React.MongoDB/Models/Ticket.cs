using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace React.MongoDB.Models;

public class Ticket
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public virtual Status Status { get; set; }
}