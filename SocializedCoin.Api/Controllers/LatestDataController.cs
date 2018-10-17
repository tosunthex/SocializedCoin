using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Repository;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatestDataController : Controller
    {
        private readonly ILatestDataReposity _reposity;
        public LatestDataController(ILatestDataReposity reposity)
        {
            _reposity = reposity;
        }

        [HttpGet]
        public async Task<IEnumerable<LatestData>> Get()
        {
            return await _reposity.Get();
        }

        [HttpGet("{id:long:min(1)}")]
        public async Task<LatestData> GetById(long id)
        {
            return await _reposity.GetById(id);
        }

        [HttpGet("{symbol:alpha}")]
        public async Task<LatestData> GetBySymbol(string symbol)
        {
            return await _reposity.GetBySymbol(symbol);
        }
    }
}