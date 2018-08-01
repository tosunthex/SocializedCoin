using MongoDB.Driver;
using Socilizedcoin.CoinMarketCap.Model;
using Socilizedcoin.CoinMarketCap.Parameters;

namespace Socilizedcoin.CoinMarketCap.Data
{
    public class TickerContext
    {
        private readonly IMongoDatabase _database = null;

        public TickerContext()
        {
            var client = new MongoClient(MongoDbSettings.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(MongoDbSettings.Database);
            }
        }

        public IMongoCollection<MongoTicker> Ticker() => _database.GetCollection<MongoTicker>("Ticker");
    }
}