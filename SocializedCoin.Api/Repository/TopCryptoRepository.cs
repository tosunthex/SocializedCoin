using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Parameters;
using SocializedCoin.Api.Services;

namespace SocializedCoin.Api.Repository
{
    public class TopCryptoRepository:ITopCryptoRepository
    {
        private readonly ICoinMarketCapClient _client;
        public TopCryptoRepository()
        {
            _client = CoinMarketCapConnection.Create();
        }
        
        public async Task<IEnumerable<TopCryptos>> GetTopGainers()
        {
            var response = await _client.CryptoCurrencyClient.GetListingLatest(1, 100, new[] {Currency.Usd},
                SortField.PercentChange24H, SortDirection.Desc, CryptoCurrencyType.All);
            return (from r in response.Data
                where r.Quote["USD"].Volume24H >= 50000
                select new TopCryptos
                {
                    Symbol = r.Symbol,
                    PercentChange24H = NumberConverter.ConvertToPercent(r.Quote["USD"].PercentChange24H),
                    Price = NumberConverter.ConvertToPrice(r.Quote["USD"].Price),
                    Volume24H = NumberConverter.ConvertToPrice(r.Quote["USD"].Volume24H)
                }).Take(10);
        }

        public async Task<IEnumerable<TopCryptos>> GetTopLosers()
        {
            var response = await _client.CryptoCurrencyClient.GetListingLatest(1, 1000, new[] {Currency.Usd},
                SortField.PercentChange24H, SortDirection.Asc, CryptoCurrencyType.All);

            return (from r in response.Data
                where r.Quote["USD"].Volume24H >= 50000 && r.Quote["USD"].PercentChange24H != null
                                                        && r.Quote["USD"].Price != null
                select new TopCryptos
                {
                    Symbol = r.Symbol,
                    Price = NumberConverter.ConvertToPrice(r.Quote["USD"].Price),
                    PercentChange24H = NumberConverter.ConvertToPercent(r.Quote["USD"].PercentChange24H),
                    Volume24H = NumberConverter.ConvertToPrice(r.Quote["USD"].Volume24H)
                }).Take(10);
        }
    }
}