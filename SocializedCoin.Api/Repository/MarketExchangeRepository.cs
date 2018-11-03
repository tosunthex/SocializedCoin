using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoCompare_Api.Clients;
using CryptoCompare_Api.Models.Responses.Price;
using MongoDB.Bson;
using MongoDB.Driver;
using SocializedCoin.Api.Data;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public class MarketExchangeRepository:IMarketExchangeRepository
    {
        private readonly CryptoCompareContext _cryptoCompareContext = null;
        private readonly CoinMarketCapContext _coinMarketCapContext = null;
        private readonly CryptoCompareClient _client;
        public MarketExchangeRepository()
        {
            _cryptoCompareContext = new CryptoCompareContext();
            _coinMarketCapContext = new CoinMarketCapContext();
            _client = new CryptoCompareClient();
        }
        
        public async Task<IEnumerable<MarketExchangesPrice>> GetMarketLatestDataBySymbol(string symbol)
        {
            var exchanges = await _cryptoCompareContext.GetMarketExchangeCollection.Find(Builders<MarketExchanges>.Filter.Exists("CryptoExchanges."+symbol,true)).Project(ex => new {MarketName = ex.MarketName, CryptoExchange = ex.CryptoExchanges[symbol]}).ToListAsync();
            var result = new List<MarketExchangesPrice>();
            foreach (var item in exchanges)
            {
                var marketName = item.MarketName;
                var marketExchangePrice = new MarketExchangesPrice
                {
                    MarketName = marketName,
                    MultipleSymbolFullData = new Dictionary<string,DisplayCryptoData>()
                };
                foreach (var toCrypto in item.CryptoExchange)
                {
                    var fromCrypto = symbol;
                    var exchangePrice = await 
                        _client.PriceClient.GetMultipleSymbolFullData(new string[]{fromCrypto}, new string[]{toCrypto}, false, marketName);
                    marketExchangePrice.MultipleSymbolFullData.Add(toCrypto,exchangePrice.Display[fromCrypto][toCrypto]);
                }
                result.Add(marketExchangePrice);
            }
            return result;
        }
    }
}