using System;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SocilizedCoin.CoinMarketCap.Model
{
    public class CryptoCurrencyGeneralData
    {
        [BsonId] 
        public ObjectId ObjectId { get; set; }

        public CryptoCurrencyInfoData CryptoCurrencyInfoData { get; set; }
        public DateTime RecordDateTime { get; set; }
    }
}