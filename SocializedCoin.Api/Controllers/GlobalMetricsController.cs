using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Repository;

namespace SocializedCoin.Api.Controllers
{
    public class GlobalMetricsController : Controller
    {
        private readonly IGlobalMetricsRepository _repository;
        public GlobalMetricsController(IGlobalMetricsRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ResponseMain<GlobalMetricsLatestData>> GetGlobalMetrics()
        {
            return await _repository.GetGlobalMetrics();
        }
        
    }
}