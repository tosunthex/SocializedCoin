using System.Linq;
using MongoDB.Driver;
using SocializedCoin.Core.Entities;
using SocializedCoin.Infrastructure.Settings;

namespace SocializedCoin.Infrastructure.Data
{
    public class MongoDbContext<T> where T : BaseEntity
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext(string databaseName)
        {
            var client = new MongoClient(MongoDbSettings.ConnectionString);
            _database = client.GetDatabase(databaseName);
        }
        public IMongoCollection<T> GetMongoCollection() => _database.GetCollection<T>(typeof(T).ToString().Split('.').Last());
 
    }
}