using System;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using SocializedCoin.Core.Entities;
using SocilizedCoin.CoinMarketCap.Data;
using SocilizedCoin.CoinMarketCap.Model;
using SocilizedCoin.CoinMarketCap.Repository;

namespace SocializedCoin.CoinMarketCap.Repository
{
    public class CoinMarketCapRepository:ICoinMarketCapRepository
    {
        private readonly CoinMarketCapContext _context = null;

        public CoinMarketCapRepository()
        {
            _context = new CoinMarketCapContext();
        }
        
        public async Task<CoinMarketCapLatestData> GetTicker()
        {
            try
            {
                return await _context.LastestCrpytoCurrencyData().Find(_ => true).FirstAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;    
            }
        }

        public async Task AddTicker(CoinMarketCapLatestData ticker)
        {
            try
            {
                await _context.LastestCrpytoCurrencyData().InsertOneAsync(ticker);
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
                DeleteResult actionResult =  await _context.LastestCrpytoCurrencyData().DeleteOneAsync(Builders<CoinMarketCapLatestData>.Filter.Eq("Id",id));
                return actionResult.IsAcknowledged 
                       && actionResult.DeletedCount > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task AddGeneralData(CryptoCurrencyGeneralData cryptoCurrencyGeneralData)
        {
            try
            {
                await _context.CryptoCurrencyGeneralData().InsertOneAsync(cryptoCurrencyGeneralData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;    
            } 
        }
    }
}