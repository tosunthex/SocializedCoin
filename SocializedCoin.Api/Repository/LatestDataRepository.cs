using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocializedCoin.Api.Data;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public class LatestDataRepository:ILatestDataRepository
    {
        private readonly CoinMarketCapContext _context =null;
        public LatestDataRepository()
        {
            _context = new CoinMarketCapContext();
        }
        public async Task<IEnumerable<LatestData>> Get()
        {
            try
            {
                return await _context.GetLatestCryptoCurrencyData().Find(_ => true).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<LatestData> GetBySymbol(string symbol)
        {
            return await _context.GetLatestCryptoCurrencyData().Find(_ => _.ListingLatestData.Symbol == symbol)
                .FirstOrDefaultAsync();
        }

        public async Task<LatestData> GetById(long id)
        {
            return await _context.GetLatestCryptoCurrencyData().Find(_ => _.ListingLatestData.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}