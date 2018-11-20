using System.Threading.Tasks;
using CryptoCompare_Api.Models.Responses.Price;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Repository;
using SocializedCoin.Core.Interfaces;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LatestDataController : ControllerBase
    {
        private readonly ILatestDataRepository _repository;
        public LatestDataController(ILatestDataRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("SymbolAndMarket")]
        public async Task<ServiceResponse<MultipleSymbolFullData>> GetBySymbolAndMarket(string f,string t, string m)
        {
            return new ServiceResponse<MultipleSymbolFullData>(HttpContext)
            {
                Entity = await _repository.GetBySymbolAndMarketFromCryptoCompare(f, t, m),
                IsSuccessful = true
            };
        }
        
    }
}