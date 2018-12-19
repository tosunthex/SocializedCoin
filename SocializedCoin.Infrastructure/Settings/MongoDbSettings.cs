namespace SocializedCoin.Infrastructure.Settings
{
    public class MongoDbSettings
    {
        public static string ConnectionString => "mongodb://admin:abc123!@localhost";
        public static string SocializedCoinDatabase => "SocializedCoinDatabase";
    }
}