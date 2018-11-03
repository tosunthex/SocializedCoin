using System;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocializedCoin.CryptoCompare.Model
{
    public class CoinlistData
    {
        [BsonId] public ObjectId ObjectId { get; set; }
        public DateTime RecordDateTime { get; set; }

        [DataMember] public long Id { get; set; }
        
        public string Url { get; set; }
        
        public string ImageUrl { get; set; }
        
        public string Name { get; set; }
        
        public string Symbol { get; set; }
        
        public string CoinName { get; set; }
        
        public string FullName { get; set; }
        
        public string Algorithm { get; set; }
        
        public string ProofType { get; set; }

        public long FullyPremined { get; set; }

        public string TotalCoinSupply { get; set; }

        public string BuiltOn { get; set; }

        public string SmartContractAddress { get; set; }

        public string PreMinedValue { get; set; }

        public string TotalCoinsFreeFloat { get; set; }

        public long SortOrder { get; set; }

        public bool Sponsored { get; set; }

        public bool IsTrading { get; set; }
    }
}