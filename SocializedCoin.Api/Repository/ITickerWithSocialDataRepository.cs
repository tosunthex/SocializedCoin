using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public interface ITickerWithSocialDataRepository
    {
        Task<IEnumerable<TickerWithSocialData>> Get();
    }
}