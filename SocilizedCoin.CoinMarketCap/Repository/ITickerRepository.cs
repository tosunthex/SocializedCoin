using System.Threading.Tasks;
using MongoDB.Bson;
using SocilizedCoin.CoinMarketCap.Model;

namespace SocilizedCoin.CoinMarketCap.Repository
{
    public interface ITickerRepository
    {
        Task<TickerWithSocialData> GetTicker();
        Task AddTicker(TickerWithSocialData ticker);
        Task<bool> DeleteTicker(ObjectId id);
    }
}