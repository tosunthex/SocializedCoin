using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Core.Entities;

namespace SocializedCoin.Core.Interfaces
{
    public interface ITopCryptoRepository
    {
        Task<IEnumerable<TopCryptos>> GetTopGainers();
        Task<IEnumerable<TopCryptos>> GetTopLosers();
    }
}