using CryptoCompare_Api.Models.Responses.Other;
using MongoDB.Driver;
using SocilizedCoin.CryptoCompare.Model;
using SocilizedCoin.CryptoCompare.Parameters;
using CoinlistData = SocilizedCoin.CryptoCompare.Model.CoinlistData;

namespace SocilizedCoin.CryptoCompare.Data
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
        public IMongoCollection<MarketCryptoExchanges> MarketCryptoExchangeCollection() => _dataBase.GetCollection<MarketCryptoExchanges>("MarketCryptoExchanges");
    }
}