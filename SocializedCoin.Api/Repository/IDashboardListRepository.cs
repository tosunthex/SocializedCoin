using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public interface IDashboardListRepository
    {
        Task<IEnumerable<DashboardList>> Get(string sort,string filter);
    }
}