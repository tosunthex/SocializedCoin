using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Repository;

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
        public async Task<IEnumerable<MarketExchangesPrice>> GetPriceBySymbol(string symbol)
        {
            return await _repository.GetMarketLatestDataBySymbol(symbol);
        }
    }
}