using System;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;

namespace SocializedCoin.Core.Entities
{
    public class CoinMarketCapLatestData:BaseEntity
    {
        public ListingLatestData ListingLatestData { get; set; }
        public DateTime RecordDateTime { get; set; }
    }
}