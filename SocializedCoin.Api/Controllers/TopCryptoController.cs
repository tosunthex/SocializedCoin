using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Api.Repository;
using SocializedCoin.Core.Entities;
using SocializedCoin.Core.Interfaces;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TopCryptoController : Controller
    {
        private readonly ITopCryptoRepository _repository;

        public TopCryptoController(ITopCryptoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("TopGainers")]
        public async Task<ServiceResponse<TopCryptos>> GetTopGainers()
        {
            var response = new ServiceResponse<TopCryptos>(HttpContext)
            {
                Data = await _repository.GetTopGainers(),
                IsSuccessful = true
            };
            response.Count = response.Data.Count();
            return response;
        }

        [HttpGet("TopLosers")]
        public async Task<ServiceResponse<TopCryptos>> GetTopLosers()
        {
            var response = new ServiceResponse<TopCryptos>(HttpContext)
            {
                Data = await _repository.GetTopLosers(),
                IsSuccessful = true
            };
            response.Count = response.Data.Count();
            return response;
        }
    }
}