using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorldWorkshopApi.Models;

public class World
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string WorldName { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public string Description { get; set; } = null!;
}