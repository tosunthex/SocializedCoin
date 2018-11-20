using MongoDB.Driver;
using SocializedCoin.Api.Parameters;
using SocializedCoin.Core.Entities;

namespace SocializedCoin.Api.Data
{
    public class CryptoCompareContext
    {
        private readonly IMongoDatabase _database;

        public CryptoCompareContext()
        {
            var client = new MongoClient(MongoDbSettings.ConnectionString);
            _database = client.GetDatabase(MongoDbSettings.CryptoCompareDatabase);
        }

        public IMongoCollection<MarketExchanges> GetMarketExchangeCollection =>
            _database.GetCollection<MarketExchanges>("MarketExchanges");
    }
}