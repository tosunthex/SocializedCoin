namespace SocilizedCoin.CoinMarketCap.Parameters
{
    public class MongoDbSettings
    {
        public static string ConnectionString => "mongodb://admin:abc123!@localhost";
        public static string CoinmarketcapDatabase => "CoinMarketCap";
        public static string CryptocompareDatabase => "CryptoCompare";
    }
}