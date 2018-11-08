using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;

namespace SocializedCoin.Api.Repository
{
    public interface IGlobalMetricsRepository
    {
        Task<ResponseMain<GlobalMetricsLatestData>> GetGlobalMetrics();
    }
}