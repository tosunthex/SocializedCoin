using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using CoinMarketCap.Model;
using CryptoCompare_Api.Models.Responses.Other;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocializedCoin.Api.Model
{
    public class TickerWithSocialData
    {
        [BsonId] 
        public ObjectId ObjectId { get; set; }
        
        [DataMember]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Symbol { get; set; }

        public string WebsiteSlug { get; set; }

        public long? Rank { get; set; }

        public long? CirculatingSupply { get; set; }

        public long? TotalSupply { get; set; }

        public long? MaxSupply { get; set; }

        public Dictionary<string, TickerQuotes> Quotes { get; set; }

        public long? LastUpdated { get; set; }
        
        public DateTime RecordDateTime { get; set; }

        public SocialstatData SocialstatData { get; set; }
    }
}