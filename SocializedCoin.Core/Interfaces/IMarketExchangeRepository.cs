using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Core.Entities;

namespace SocializedCoin.Core.Interfaces
{
    public interface IMarketExchangeRepository
    {
        Task<IEnumerable<MarketExchangesPrice>> GetMarketLatestDataBySymbol(string symbol);
    }
}