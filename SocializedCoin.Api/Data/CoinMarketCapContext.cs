using MongoDB.Driver;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Parameters;

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

        public IMongoCollection<LatestData> GetLatestCryptoCurrencyData() =>
            _database.GetCollection<LatestData>("LatestCryptoCurrencyData");
        public IMongoCollection<GeneralData> GetCryptoCurrencyGeneralData() =>
            _database.GetCollection<GeneralData>("CryptoCurrencyGeneralData");
    }
}