using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public interface ILatestWithGeneralDataRepository
    {
        Task<IEnumerable<LatestWithGeneralData>> Get();
        Task<LatestWithGeneralData> GetBySymbol(string symbol);
        Task<LatestWithGeneralData> GetById(long id);
    }
}