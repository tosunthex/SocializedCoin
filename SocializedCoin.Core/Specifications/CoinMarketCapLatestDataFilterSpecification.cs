using System;
using System.Linq.Expressions;
using SocializedCoin.Core.Entities;

namespace SocializedCoin.Core.Specifications
{
    public class CoinMarketCapLatestDataFilterSpecification:BaseSpecification<CoinMarketCapLatestData>
    {
        public CoinMarketCapLatestDataFilterSpecification(string symbol) : base(i => i.ListingLatestData.Symbol == symbol)
        {
        }
    }
}