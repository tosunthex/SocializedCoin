using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Core.Entities;

namespace SocializedCoin.Core.Interfaces
{
    public interface IDashboardListRepository
    {
        Task<IEnumerable<DashboardList>> Get(string sort,string filter);
    }
}