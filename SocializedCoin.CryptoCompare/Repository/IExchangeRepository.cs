using System.Collections.Generic;
using System.Threading.Tasks;
using SocilizedCoin.CryptoCompare.Model;

namespace SocilizedCoin.CryptoCompare.Repository
{
    public interface IExchangeRepository
    {
        Task AddExchange(MarketCryptoExchanges marketCryptoExchanges);
        Task<IEnumerable<MarketCryptoExchanges>> GetExchages();
        Task<MarketCryptoExchanges> GetExchangeByMarketName(string marketName);
    }
}