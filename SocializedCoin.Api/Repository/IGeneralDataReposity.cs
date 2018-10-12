using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public interface IGeneralDataReposity
    {
        Task<IEnumerable<GeneralData>> Get();
        Task<GeneralData> GetById(long id);
        Task<GeneralData> GetBySymbol(string symbol);
    }
}