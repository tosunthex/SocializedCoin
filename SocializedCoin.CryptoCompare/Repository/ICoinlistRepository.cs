using System.Threading.Tasks;
using CoinlistData = SocializedCoin.CryptoCompare.Model.CoinlistData;

namespace SocializedCoin.CryptoCompare.Repository
{
    public interface ICoinlistRepository
    {
        Task AddCoinlistData(CoinlistData coinlist);
        Task<CoinlistData> GetCoinlistData(string symbol);
        //Task<Coinlist> GetCoin(int id);
    }
}