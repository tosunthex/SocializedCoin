using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Repository;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralDataController : Controller
    {
        private readonly IGeneralDataReposity _reposity;
        public GeneralDataController(IGeneralDataReposity reposity)
        {
            _reposity = reposity;    
        }

        [HttpGet]
        public async Task<IEnumerable<GeneralData>> Get()
        {
            return await _reposity.Get();
        }

        [HttpGet("{id:long:min(1)}")]
        public async Task<GeneralData> GetById(long id)
        {
            return await _reposity.GetById(id);
        }

        [HttpGet("{symbol:alpha}")]
        public async Task<GeneralData> GetBySymbol(string symbol)
        {
            return await _reposity.GetBySymbol(symbol);
        }
    }
}