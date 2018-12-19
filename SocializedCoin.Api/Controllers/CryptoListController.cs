using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocializedCoin.Core.Entities;
using SocializedCoin.Core.Interfaces;

namespace SocializedCoin.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CryptoListController : ControllerBase
    {
        private readonly ICryptoListRepository _cryptoListRepository;

        public CryptoListController(ICryptoListRepository cryptoListRepository)
        {
            _cryptoListRepository = cryptoListRepository;
        }

        [HttpGet]
        public async Task<ServiceResponse<CryptoList>> Index()
        {
            var response = new ServiceResponse<CryptoList>(HttpContext)
            {
                Data = await _cryptoListRepository.Get(), 
                IsSuccessful = true
            };
            response.Count = response.Data.Count();
            return response;
        }
    }
}