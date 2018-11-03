using CryptoCompare_Api.Models.Responses.Other;
using MongoDB.Driver;
using SocializedCoin.CryptoCompare.Model;
using SocializedCoin.CryptoCompare.Parameters;
using CoinlistData = SocializedCoin.CryptoCompare.Model.CoinlistData;

namespace SocializedCoin.CryptoCompare.Data
{
    public class CryptoCompareContext
    {
        private readonly IMongoDatabase _dataBase = null;

        public CryptoCompareContext()
        {
            var client = new MongoClient(MongoDbSettings.ConnectionString);
            if (client != null)
            {
                _dataBase = client.GetDatabase(MongoDbSettings.Database);
            }
        }

        public IMongoCollection<SocialstatData> SocialStatCollection() => _dataBase.GetCollection<SocialstatData>("SocialstatData");
        public IMongoCollection<CoinlistData> CoinlistCollection() => _dataBase.GetCollection<CoinlistData>("CoinListData");
        public IMongoCollection<MarketExchanges> MarketExchangesCollection() => _dataBase.GetCollection<MarketExchanges>("MarketExchanges");
    }
}