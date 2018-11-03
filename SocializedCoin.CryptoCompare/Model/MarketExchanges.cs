using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocializedCoin.CryptoCompare.Model
{
    public class MarketExchanges
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string MarketName { get; set; }
        public IReadOnlyDictionary<string,IReadOnlyList<string>> CryptoExchanges { get; set; }
        public DateTime RecordDate { get; set; }
    }
}