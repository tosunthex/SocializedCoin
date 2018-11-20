using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;

namespace SocializedCoin.Core.Interfaces
{
    public interface IGlobalMetricsRepository
    {
        Task<ResponseMain<GlobalMetricsLatestData>> GetGlobalMetrics();
    }
}