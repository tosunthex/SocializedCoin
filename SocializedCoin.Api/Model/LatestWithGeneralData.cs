using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;

namespace SocializedCoin.Api.Model
{
    public class LatestWithGeneralData
    {
        public ListingLatestData ListingLatestData { get; set; }
        public CryptoCurrencyInfoData CryptoCurrencyInfoData { get; set; }
    }
}