using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public interface ITopCryptoRepository
    {
        Task<IEnumerable<TopCryptos>> GetTopGainers();
        Task<IEnumerable<TopCryptos>> GetTopLosers();
    }
}