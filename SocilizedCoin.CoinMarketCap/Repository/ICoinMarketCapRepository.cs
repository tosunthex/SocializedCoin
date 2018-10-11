using System.Threading.Tasks;
using MongoDB.Bson;
using SocilizedCoin.CoinMarketCap.Model;

namespace SocilizedCoin.CoinMarketCap.Repository
{
    public interface ICoinMarketCapRepository
    {
        Task<LatestCryptoCurrencyData> GetTicker();
        Task AddTicker(LatestCryptoCurrencyData ticker);
        Task<bool> DeleteTicker(ObjectId id);
        Task AddGeneralData(CryptoCurrencyGeneralData cryptoCurrencyGeneralData);
    }
}