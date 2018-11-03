using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocializedCoin.CryptoCompare.Data;
using SocializedCoin.CryptoCompare.Model;

namespace SocializedCoin.CryptoCompare.Repository
{
    public class ExchangeRepository:IExchangeRepository
    {
        private readonly CryptoCompareContext _context;
        public ExchangeRepository()
        {
            _context = new CryptoCompareContext();
        }
        public async Task AddExchange(MarketExchanges marketCryptoExchanges)
        {
            try
            {
                await _context.MarketExchangesCollection().InsertOneAsync(marketCryptoExchanges);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<MarketExchanges>> GetExchages()
        {
            try
            {
                return await _context.MarketExchangesCollection().Find(_ => true).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<MarketExchanges> GetExchangeByMarketName(string marketName)
        {
            try
            {
                return await _context.MarketExchangesCollection().Find(_ => _.MarketName == marketName)
                    .FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}