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
    public class DashboardListController : ControllerBase
    {
        private readonly IDashboardListRepository _repository;
        public DashboardListController(IDashboardListRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<ServiceResponse<DashboardList>> GetDashBoardList(string sort,int? page,int? per_page,string filter)
        {
            var shortValue= "";
            if (!string.IsNullOrEmpty(sort))
            {
                shortValue = sort.Replace('|', ' ').ToUpper();
            }
            
            var response = new ServiceResponse<DashboardList>(HttpContext)
            {
                Data = await _repository.Get(shortValue,filter),
                IsSuccessful = true
            };
            response.Count = response.Data.Count();
            return response;
        }
    }
}