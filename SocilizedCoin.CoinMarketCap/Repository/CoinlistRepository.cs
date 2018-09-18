using System;
using System.Threading.Tasks;
using CryptoCompare_Api.Models.Responses.Other;
using MongoDB.Driver;
using SocilizedCoin.CoinMarketCap.Data;
using SocilizedCoin.CoinMarketCap.Model;

namespace SocilizedCoin.CoinMarketCap.Repository
{
    public class CoinlistRepository:ICoinlistRepository
    {
        private readonly CryptoCompareContext _context;
        
        public CoinlistRepository()
        {
            _context = new CryptoCompareContext();
        }
        public async Task<CoinlistDataDb> GetCoinlistDataByCoinName(string name)
        {
            try
            {
                return await _context.CoinlistDataCollection().Find(coin => coin.CoinName == name).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public async Task<CoinlistDataDb> GetCoinlistDataBySymbol(string symbol)
        {
            try
            {
                return await _context.CoinlistDataCollection().Find(coin => coin.Symbol == symbol).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}