using System;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;

namespace SocializedCoin.Core.Entities
{
    public class GeneralData:BaseEntity
    {
        public CryptoCurrencyInfoData CryptoCurrencyInfoData { get; set; }
        public DateTime RecordDateTime { get; set; }
    }
}