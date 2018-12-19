using System.Collections.Generic;
using System.Threading.Tasks;
using CryptoCompare_Api.Clients;
using CryptoCompare_Api.Models.Responses.Price;
using MongoDB.Driver;
using SocializedCoin.Api.Data;
using SocializedCoin.Core.Entities;
using SocializedCoin.Core.Interfaces;
using SocializedCoin.Core.Specifications;
using SocializedCoin.Infrastructure.Data;

namespace SocializedCoin.Api.Repository
{
    public class MarketExchangeRepository:IMarketExchangeRepository
    {
        private readonly CryptoCompareContext _cryptoCompareContext = null;
        private readonly IAsyncRepository<MarketExchanges> _marketExchangesRepository;
        private readonly CryptoCompareClient _client;
        public MarketExchangeRepository()
        {
            _cryptoCompareContext = new CryptoCompareContext();
            _client = new CryptoCompareClient();
            _marketExchangesRepository = new MongoRepository<MarketExchanges>();
        }
        
        public async Task<IEnumerable<MarketExchangesPrice>> GetMarketLatestDataBySymbol(string symbol)
        {
            var exchanges = await _cryptoCompareContext.GetMarketExchangeCollection
                .Find(Builders<MarketExchanges>.Filter.Exists("CryptoExchanges." + symbol, true))
                .Project(ex => new {ex.MarketName, CryptoExchange = ex.CryptoExchanges[symbol]})
                .Sort(Builders<MarketExchanges>.Sort.Ascending("MarketName")).ToListAsync();
            var m = new MarketExchangesFilterSpecification(symbol);
            var a = await _marketExchangesRepository.GetBySpecAsync(m);
            
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
                        _client.PriceClient.GetMultipleSymbolFullData(new []{fromCrypto}, new []{toCrypto}, false, marketName);
                    marketExchangePrice.MultipleSymbolFullData.Add(toCrypto,exchangePrice.Display[fromCrypto][toCrypto]);
                }
                result.Add(marketExchangePrice);
            }
            return result;
        }
    }
}