using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocializedCoin.Api.Data;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public class TickerWithSocialDataRepository:ITickerWithSocialDataRepository
    {
        private readonly CoinMarketCapContext _context =null;
        public TickerWithSocialDataRepository()
        {
            _context = new CoinMarketCapContext();
        }
        public async Task<IEnumerable<TickerWithSocialData>> Get()
        {
            try
            {
                return await _context.TickerWithSocialData().Find(_ => true).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}