using MongoDB.Driver;
using SocializedCoin.Core.Entities;
using SocilizedCoin.CoinMarketCap.Model;
using SocilizedCoin.CoinMarketCap.Parameters;

namespace SocilizedCoin.CoinMarketCap.Data
{
    public class CoinMarketCapContext
    {
        private readonly IMongoDatabase _database = null;

        public CoinMarketCapContext()
        {
            var client = new MongoClient(MongoDbSettings.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(MongoDbSettings.CoinmarketcapDatabase);
            }
        }

        public IMongoCollection<CoinMarketCapLatestData> LastestCrpytoCurrencyData() => _database.GetCollection<CoinMarketCapLatestData>("LatestCryptoCurrencyData");
        public IMongoCollection<CryptoCurrencyGeneralData> CryptoCurrencyGeneralData() => _database.GetCollection<CryptoCurrencyGeneralData>("CryptoCurrencyGeneralData");
    }
}