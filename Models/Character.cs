using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorldWorkshopApi.Models;

public class Character
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

     [BsonElement("Name")]
    public string CharacterName { get; set; } = null!;

    public string Description {get; set;} = null!;

    public string Abilities { get; set; } = null!;

}