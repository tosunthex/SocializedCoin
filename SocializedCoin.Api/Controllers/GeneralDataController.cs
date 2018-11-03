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
    public class GeneralDataController : Controller
    {
        private readonly IGeneralDataRepository _repository;
        public GeneralDataController(IGeneralDataRepository repository)
        {
            _repository = repository;    
        }

        [HttpGet]
        public async Task<IEnumerable<GeneralData>> Get()
        {
            return await _repository.Get();
        }

        [HttpGet("{id:long:min(1)}")]
        public async Task<GeneralData> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        [HttpGet("{symbol:alpha}")]
        public async Task<GeneralData> GetBySymbol(string symbol)
        {
            return await _repository.GetBySymbol(symbol);
        }
    }
}