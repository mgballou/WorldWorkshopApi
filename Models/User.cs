using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WorldWorkshopApi.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }


    public string email { get; set; } = null!;

    public string password { get; set; } = null!;




}