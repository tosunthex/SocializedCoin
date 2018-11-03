using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Repository;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LatestDataController : Controller
    {
        private readonly ILatestDataRepository _repository;
        public LatestDataController(ILatestDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<LatestData>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet("{id:long:min(1)}")]
        public async Task<LatestData> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        [HttpGet("{symbol:alpha}")]
        public async Task<LatestData> GetBySymbol(string symbol)
        {
            return await _repository.GetBySymbol(symbol);
        }
    }
}