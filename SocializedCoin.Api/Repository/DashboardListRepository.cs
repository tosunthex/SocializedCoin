using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;
using SocializedCoin.Api.Model;
using SocializedCoin.Api.Services;
using SocializedCoin.Api.Parameters;

namespace SocializedCoin.Api.Repository
{
    public class DashboardListRepository:IDashboardListRepository
    {
        private readonly ICoinMarketCapClient _client;

        public DashboardListRepository()
        {
            _client = CoinMarketCapConnection.Create();
        }
        
        public async Task<IEnumerable<DashboardList>> Get(string sort,string filter)
        {
            try
            {
                var result = await _client.CryptoCurrencyClient.GetListingLatest(1, 100, new[] {Currency.Usd},
                    SortField.MarketCap, "desc", "");
                var queryResult = (from r in result.Data
                        select new DashboardList
                        {
                            Display = new DashBoardListDisplay
                            {
                                CirculatingSupply = string.Format("{0} {1}",
                                    NumberConverter.ConvertToNumber(r.CirculatingSupply), r.Symbol),
                                MarketCap = NumberConverter.ConvertToPrice(r.Quote["USD"].MarketCap),
                                PercentChange24H = NumberConverter.ConvertToPercent(r.Quote["USD"].PercentChange24H),
                                Price = NumberConverter.ConvertToPrice(r.Quote["USD"].Price),
                                Volume24H = NumberConverter.ConvertToPrice(r.Quote["USD"].Volume24H)
                            },
                            Values = new DashboardListValues
                            {
                                CirculatingSupply = r.CirculatingSupply,
                                MarketCap = r.Quote["USD"].MarketCap,
                                PercentChange24H = r.Quote["USD"].PercentChange24H,
                                Price = r.Quote["USD"].Price,
                                Volume24H = r.Quote["USD"].Volume24H
                            },
                            CmcRank = r.CmcRank,
                            Name = r.Name,
                            Symbol = r.Symbol
                        }
                    );
                if (!string.IsNullOrEmpty(filter))
                {
                    queryResult = queryResult.Where(q => q.Name.ToUpper().Contains(filter.ToUpper()));
                }
                return string.IsNullOrEmpty(sort) ? queryResult :queryResult.AsQueryable().OrderBy(sort);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}