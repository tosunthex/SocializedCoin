
using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCap.Reposity;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Repository;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerWithSocialDataController:ControllerBase
    {
        private readonly ITickerWithSocialDataRepository _tickerWithSocialDataRepository;

        public TickerWithSocialDataController(ITickerWithSocialDataRepository tickerWithSocialDataRepository)
        {
            _tickerWithSocialDataRepository = tickerWithSocialDataRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<TickerWithSocialData>> Get()
        {
            return await _tickerWithSocialDataRepository.Get();
        }
    }
}