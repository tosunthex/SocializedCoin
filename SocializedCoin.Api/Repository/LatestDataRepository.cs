using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using CoinMarketCapPro_API.Parameters;
using MongoDB.Driver;
using SocializedCoin.Api.Data;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Parameters;
using SortDirection = MongoDB.Driver.SortDirection;

namespace SocializedCoin.Api.Repository
{
    public class LatestDataRepository : ILatestDataRepository
    {
        private readonly CoinMarketCapContext _context = null;
        private readonly ICoinMarketCapClient _client;

        public LatestDataRepository()
        {
            _context = new CoinMarketCapContext();
            _client = CoinMarketCapConnection.Create();
        }

        public async Task<ResponseMain<ListingLatestData[]>> Get()
        {
            try
            {
                return await _client.CryptoCurrencyClient.GetListingLatest(1, 100, new[] {Currency.Usd},
                    SortField.MarketCap, "desc", "");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<LatestData> GetBySymbol(string symbol)
        {
            return await _context.GetLatestCryptoCurrencyData().Find(_ => _.ListingLatestData.Symbol == symbol)
                .FirstOrDefaultAsync();
        }

        public async Task<LatestData> GetById(long id)
        {
            return await _context.GetLatestCryptoCurrencyData().Find(_ => _.ListingLatestData.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TopCryptos>> GetTopGainers()
        {
            var response = await _client.CryptoCurrencyClient.GetListingLatest(1, 100, new[] {Currency.Usd},
                SortField.Volume24H, "desc", "");
            return (from r in response.Data
                where r.Quote["USD"].Volume24H >= 50000
                select new TopCryptos
                {
                    Symbol = r.Symbol,
                    Percent = r.Quote["USD"].PercentChange24H,
                    Price = r.Quote["USD"].Price
                }).Take(5);
        }

        public async Task<IEnumerable<TopCryptos>> GetTopLosers()
        {
            var response = await _client.CryptoCurrencyClient.GetListingLatest(1, 100, new[] {Currency.Usd},
                SortField.PercentChange24H, CoinMarketCapPro_API.Parameters.SortDirection.Asc,CryptoCurrencyType.All);
            
            return (from r in response.Data
                where r.Quote["USD"].Volume24H >= 50000
                select new TopCryptos
                {
                    Symbol = r.Symbol,
                    Percent = r.Quote["USD"].PercentChange24H,
                    Price = r.Quote["USD"].Price
                }).Take(5);
        }

        public Task<MarketVolume> GetMarketVolume()
        {
            throw new NotImplementedException();
        }
    }
}