using MongoDB.Driver;
using SocializedCoin.Api.Parameters;
using SocializedCoin.Core.Entities;

namespace SocializedCoin.Api.Data
{
    public class CoinMarketCapContext
    {
        private readonly IMongoDatabase _database = null;
        public CoinMarketCapContext()
        {
            var client = new MongoClient(MongoDbSettings.ConnectionString);
            _database = client.GetDatabase(MongoDbSettings.CoinmarketcapDatabase);
        }

        public IMongoCollection<LatestCryptoCurrencyData> GetLatestCryptoCurrencyData() => _database.GetCollection<LatestCryptoCurrencyData>("LatestCryptoCurrencyData");
        public IMongoCollection<GeneralData> GetCryptoCurrencyGeneralData() =>
            _database.GetCollection<GeneralData>("CryptoCurrencyGeneralData");
    }
}