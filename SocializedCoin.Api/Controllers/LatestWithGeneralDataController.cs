using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Repository;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LatestWithGeneralDataController:ControllerBase
    {
        private readonly ILatestWithGeneralDataReposity _latestWithGeneralDataReposity;

        public LatestWithGeneralDataController(ILatestWithGeneralDataReposity latestWithGeneralDataReposity)
        {
            _latestWithGeneralDataReposity = latestWithGeneralDataReposity;
        }
        [HttpGet]
        public async Task<IEnumerable<LatestWithGeneralData>> Get()
        {
            return await _latestWithGeneralDataReposity.Get();
        }

        [HttpGet("{id:long}")]
        public async Task<LatestWithGeneralData> GetById(long id)
        {
            return await _latestWithGeneralDataReposity.GetById(id);
        }

        [HttpGet("{symbol:alpha}")]
        public async Task<LatestWithGeneralData> GetBySymbol(string symbol)
        {
            return await _latestWithGeneralDataReposity.GetBySymbol(symbol);
        }
    }
}