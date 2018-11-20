using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Core.Entities;

namespace SocializedCoin.Core.Interfaces
{
    public interface IGeneralDataRepository
    {
        Task<IEnumerable<GeneralData>> Get();
        Task<GeneralData> GetById(long id);
        Task<GeneralData> GetBySymbol(string symbol);
    }
}