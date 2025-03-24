using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace React.MongoDB.Models;

public class Status
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    public string Value { get; set; } = string.Empty;
}