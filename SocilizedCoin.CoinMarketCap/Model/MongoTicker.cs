using System;
using CoinMarketCap.Model;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Socilizedcoin.CoinMarketCap.Model
{
    public class MongoTicker:TickersData
    {
        [BsonId] 
        public ObjectId ObjectId { get; set; }

        public DateTime RecordDateTime { get; set; }
        
    }
}