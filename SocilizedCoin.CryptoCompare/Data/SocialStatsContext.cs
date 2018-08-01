using CryptoCompare.Parameters;
using CryptoCompare_Api.Models.Responses.Other;
using MongoDB.Driver;

namespace CryptoCompare.Data
{
    public class SocialStatsContext
    {
        private readonly IMongoDatabase _dataBase = null;

        public SocialStatsContext()
        {
            var client = new MongoClient(MongoDbSettings.ConnectionString);
            if (client != null)
            {
                _dataBase = client.GetDatabase(MongoDbSettings.Database);
            }
        }

        public IMongoCollection<Socialstat> SocialStat() => _dataBase.GetCollection<Socialstat>("Socialstat");
    }
}