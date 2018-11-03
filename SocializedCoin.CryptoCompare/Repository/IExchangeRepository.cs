using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.CryptoCompare.Model;

namespace SocializedCoin.CryptoCompare.Repository
{
    public interface IExchangeRepository
    {
        Task AddExchange(MarketExchanges marketCryptoExchanges);
        Task<IEnumerable<MarketExchanges>> GetExchages();
        Task<MarketExchanges> GetExchangeByMarketName(string marketName);
    }
}