using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Core.Entities;

namespace SocializedCoin.Core.Interfaces
{
    public interface ICryptoListRepository
    {
        Task<IEnumerable<CryptoList>> Get();
    }
}