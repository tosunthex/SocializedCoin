using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocializedCoin.CryptoCompare.Data;
using CoinlistData = SocializedCoin.CryptoCompare.Model.CoinlistData;

namespace SocializedCoin.CryptoCompare.Repository
{
    public class CoinlistReposity:ICoinlistRepository
    {
        private readonly CryptoCompareContext _context;

        public CoinlistReposity()
        {
            _context = new CryptoCompareContext();
        }
        public async Task AddCoinlistData(CoinlistData coinlist)
        {
            try
            {
                await _context.CoinlistCollection().InsertOneAsync(coinlist);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<CoinlistData> GetCoinlistData(string symbol)
        {
            try
            {
                return await _context.CoinlistCollection().Find(coin => coin.Symbol == symbol).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}