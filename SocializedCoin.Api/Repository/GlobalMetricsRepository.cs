using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Parameters;
using SocializedCoin.Api.Parameters;

namespace SocializedCoin.Api.Repository
{
    public class GlobalMetricsRepository:IGlobalMetricsRepository
    {
        private readonly ICoinMarketCapClient _client;

        public GlobalMetricsRepository()
        {
            _client = CoinMarketCapConnection.Create();
        }
        
        
        public async Task<ResponseMain<GlobalMetricsLatestData>> GetGlobalMetrics()
        {
            return await _client.GlobalMetricClient.GetGlobalMetricsLatest(new[] {Currency.Usd});
        }
    }
}