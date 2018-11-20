using System;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocializedCoin.Api.Model
{
    public class LatestCryptoCurrencyData
    {
        [BsonId] 
        public ObjectId ObjectId { get; set; }
        public ListingLatestData ListingLatestData { get; set; }
        public DateTime RecordDateTime { get; set; }
    }
}