using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Core.Entities;
using SocializedCoin.Core.Interfaces;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MarketExchangesController:Controller
    {
        private readonly IMarketExchangeRepository _repository;

        public MarketExchangesController(IMarketExchangeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{symbol:alpha}")]
        public async Task<ServiceResponse<MarketExchangesPrice>> GetPriceBySymbol(string symbol)
        {
            var response = new ServiceResponse<MarketExchangesPrice>(HttpContext)
            {
                Data = await _repository.GetMarketLatestDataBySymbol(symbol),
                IsSuccessful = true
            };
            response.Count = response.Data.Count();
            return response;
        }
    }
}