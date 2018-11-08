using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public interface ILatestDataRepository
    {
        Task<ResponseMain<ListingLatestData[]>> Get();
        Task<LatestData> GetBySymbol(string symbol);
        Task<LatestData> GetById(long id);
        Task<IEnumerable<TopCryptos>> GetTopGainers();
        Task<IEnumerable<TopCryptos>> GetTopLosers();
        Task<MarketVolume> GetMarketVolume();
    }
}