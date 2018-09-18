using System.Threading.Tasks;
using CryptoCompare_Api.Models.Responses.Other;
using SocilizedCoin.CoinMarketCap.Model;

namespace SocilizedCoin.CoinMarketCap.Repository
{
    public interface ICoinlistRepository
    {
        Task<CoinlistDataDb> GetCoinlistDataByCoinName(string symbol);
        Task<CoinlistDataDb> GetCoinlistDataBySymbol(string symbol);
    }
}