using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocilizedCoin.CryptoCompare.Data;
using SocilizedCoin.CryptoCompare.Model;

namespace SocilizedCoin.CryptoCompare.Repository
{
    public class ExchangeRepository:IExchangeRepository
    {
        private readonly CryptoCompareContext _context;
        public ExchangeRepository()
        {
            _context = new CryptoCompareContext();
        }
        public async Task AddExchange(MarketCryptoExchanges marketCryptoExchanges)
        {
            try
            {
                await _context.MarketCryptoExchangeCollection().InsertOneAsync(marketCryptoExchanges);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<MarketCryptoExchanges>> GetExchages()
        {
            try
            {
                return await _context.MarketCryptoExchangeCollection().Find(_ => true).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<MarketCryptoExchanges> GetExchangeByMarketName(string marketName)
        {
            try
            {
                return await _context.MarketCryptoExchangeCollection().Find(_ => _.MarketName == marketName)
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