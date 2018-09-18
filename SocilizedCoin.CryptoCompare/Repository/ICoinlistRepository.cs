using System.Threading.Tasks;
using CryptoCompare_Api.Models.Responses.Other;
using SocilizedCoin.CryptoCompare.Model;
using CoinlistData = SocilizedCoin.CryptoCompare.Model.CoinlistData;

namespace SocilizedCoin.CryptoCompare.Repository
{
    public interface ICoinlistRepository
    {
        Task AddCoinlistData(CoinlistData coinlist);
        Task<CoinlistData> GetCoinlistData(string symbol);
        //Task<Coinlist> GetCoin(int id);
    }
}