using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SocilizedCoin.CoinMarketCap.Data;
using SocilizedCoin.CoinMarketCap.Model;

namespace SocilizedCoin.CoinMarketCap.Repository
{
    public class TickerRepository:ITickerRepository
    {
        private readonly CoinMarketCapContext _context = null;

        public TickerRepository()
        {
            _context = new CoinMarketCapContext();
        }
        
        public async Task<TickerWithSocialData> GetTicker()
        {
            try
            {
                return await _context.Ticker().Find(_ => true).FirstAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;    
            }
        }

        public async Task AddTicker(TickerWithSocialData ticker)
        {
            try
            {
                await _context.Ticker().InsertOneAsync(ticker);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;    
            }
        }

        public async Task<bool> DeleteTicker(ObjectId id)
        {
            try
            {
                DeleteResult actionResult =  await _context.Ticker().DeleteOneAsync(Builders<TickerWithSocialData>.Filter.Eq("Id",id));
                return actionResult.IsAcknowledged 
                       && actionResult.DeletedCount > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}