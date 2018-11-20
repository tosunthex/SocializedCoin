using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using CryptoCompare_Api.Models.Responses.Price;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Repository;

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