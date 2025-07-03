using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbEntityFramework.Models;

namespace Portfolio.Models;

public class BaseModel : IEntity
{
    [BsonId]
    public ObjectId Id { get; set; }
}