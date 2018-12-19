using System.Threading.Tasks;
using MongoDB.Bson;
using SocializedCoin.Core.Entities;
using SocilizedCoin.CoinMarketCap.Model;

namespace SocilizedCoin.CoinMarketCap.Repository
{
    public interface ICoinMarketCapRepository
    {
        Task<CoinMarketCapLatestData> GetTicker();
        Task AddTicker(CoinMarketCapLatestData ticker);
        Task<bool> DeleteTicker(ObjectId id);
        Task AddGeneralData(CryptoCurrencyGeneralData cryptoCurrencyGeneralData);
    }
}