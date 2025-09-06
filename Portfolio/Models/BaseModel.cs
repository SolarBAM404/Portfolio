using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio.Models;

public class BaseModel
{
    [BsonId]
    public ObjectId _id { get; set; }
}