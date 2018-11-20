using System.Threading.Tasks;
using CoinMarketCapPro;
using CoinMarketCapPro_API.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Repository;
using SocializedCoin.Core.Interfaces;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GlobalMetricsController : Controller
    {
        private readonly IGlobalMetricsRepository _repository;
        public GlobalMetricsController(IGlobalMetricsRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ServiceResponse<ResponseMain<GlobalMetricsLatestData>>> GetGlobalMetrics()
        {
            var response = new ServiceResponse<ResponseMain<GlobalMetricsLatestData>>(HttpContext)
            {
                Entity = await _repository.GetGlobalMetrics(),
                IsSuccessful = true
            };
            
            return response;
        }
        
    }
}