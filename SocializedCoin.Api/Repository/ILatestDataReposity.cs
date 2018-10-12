using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public interface ILatestDataReposity
    {
        Task<IEnumerable<LatestData>> Get();
        Task<LatestData> GetBySymbol(string symbol);
        Task<LatestData> GetById(long id);
    }
}