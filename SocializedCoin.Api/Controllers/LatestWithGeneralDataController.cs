using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Repository;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LatestWithGeneralDataController:ControllerBase
    {
        private readonly ILatestWithGeneralDataRepository _repository;

        public LatestWithGeneralDataController(ILatestWithGeneralDataRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IEnumerable<LatestWithGeneralData>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet("{id:long:min(1)}")]
        public async Task<LatestWithGeneralData> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        [HttpGet("{symbol:alpha}")]
        public async Task<LatestWithGeneralData> GetBySymbol(string symbol)
        {
            return await _repository.GetBySymbol(symbol);
        }
        
        [HttpGet("NamesSymbols")]
        public async Task<IEnumerable<CryptoList>> GetCryptoNamesAndSymbol()
        {
            var result = await _repository.Get();

            return result.OrderBy(r => r.ListingLatestData.CmcRank).Select(r1 => new CryptoList
            {
                Name = r1.CryptoCurrencyInfoData.Name, 
                Symbol = r1.CryptoCurrencyInfoData.Symbol,
                Logo = r1.CryptoCurrencyInfoData.Logo, 
                Rank = r1.ListingLatestData.CmcRank
            }).ToList();
        }
    }
}