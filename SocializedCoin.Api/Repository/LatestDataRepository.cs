using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using CryptoCompare_Api.Clients;
using CryptoCompare_Api.Models.Responses.Price;
using MongoDB.Driver;
using SocializedCoin.Api.Data;
using SocializedCoin.Api.Parameters;
using SocializedCoin.Core.Entities;
using SocializedCoin.Core.Interfaces;

namespace SocializedCoin.Api.Repository
{
    public class LatestDataRepository : ILatestDataRepository
    {
        private readonly CoinMarketCapContext _context = null;
        private readonly ICoinMarketCapClient _coinMarketCapClient;
        private readonly ICryptoCompareClient _cryptoCompareClient;
        public LatestDataRepository()
        {
            _cryptoCompareClient = new CryptoCompareClient(new HttpClientHandler());
            _context = new CoinMarketCapContext();
            _coinMarketCapClient = CoinMarketCapConnection.Create();
        }

        public async Task<ResponseMain<Dictionary<string, CryptoCurrencyInfoData>>> GetBySymbol(string symbol)
        {
            return await _coinMarketCapClient.CryptoCurrencyClient.GetMetaData(new[] {symbol});
        }

        public async Task<CoinMarketCapLatestData> GetBySymbolFromDatabase(string symbol)
        {
            return await _context.GetLatestCryptoCurrencyData().Find(_ => _.ListingLatestData.Symbol == symbol)
                .FirstOrDefaultAsync();
        }

        public async Task<MultipleSymbolFullData> GetBySymbolAndMarketFromCryptoCompare(string fromSymbol,string toSymbol,string market)
        {
            return await _cryptoCompareClient.PriceClient.GetMultipleSymbolFullData(new[] {fromSymbol}, new[] {toSymbol},
                false, market);
        }
    }
}