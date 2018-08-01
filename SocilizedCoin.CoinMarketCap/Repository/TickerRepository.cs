using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Socilizedcoin.CoinMarketCap.Data;
using Socilizedcoin.CoinMarketCap.Model;

namespace Socilizedcoin.CoinMarketCap.Repository
{
    public class TickerRepository:ITickerRepository
    {
        private readonly TickerContext _context = null;

        public TickerRepository()
        {
            _context = new TickerContext();
        }
        
        public async Task<MongoTicker> GetTicker()
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

        public async Task AddTicker(MongoTicker ticker)
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
                DeleteResult actionResult =  await _context.Ticker().DeleteOneAsync(Builders<MongoTicker>.Filter.Eq("Id",id));
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