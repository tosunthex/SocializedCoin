using System.Threading.Tasks;
using MongoDB.Bson;
using Socilizedcoin.CoinMarketCap.Model;

namespace Socilizedcoin.CoinMarketCap.Repository
{
    public interface ITickerRepository
    {
        Task<MongoTicker> GetTicker();
        Task AddTicker(MongoTicker ticker);
        Task<bool> DeleteTicker(ObjectId id);
    }
}