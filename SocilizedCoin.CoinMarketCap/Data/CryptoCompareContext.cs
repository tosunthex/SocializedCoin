using CryptoCompare_Api.Models.Responses.Other;
using MongoDB.Driver;
using SocilizedCoin.CoinMarketCap.Model;
using SocilizedCoin.CoinMarketCap.Parameters;

namespace SocilizedCoin.CoinMarketCap.Data
{
    public class CryptoCompareContext
    {
        private static IMongoDatabase _database = null;

        public CryptoCompareContext()
        {
            var client = new MongoClient(MongoDbSettings.ConnectionString);
            _database = client.GetDatabase(MongoDbSettings.CryptocompareDatabase);
        }

        public IMongoCollection<CoinlistDataDb> CoinlistDataCollection() => 
            _database.GetCollection<CoinlistDataDb>("CoinListData");
    }
}