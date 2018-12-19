using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocializedCoin.Core.Entities
{
    public class BaseEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
    }
}