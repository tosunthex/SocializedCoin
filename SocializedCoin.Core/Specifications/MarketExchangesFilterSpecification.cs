using System;
using System.Linq.Expressions;
using MongoDB.Driver;
using SocializedCoin.Core.Entities;

namespace SocializedCoin.Core.Specifications
{
    public class MarketExchangesFilterSpecification:BaseSpecification<MarketExchanges>
    {
        public MarketExchangesFilterSpecification(string symbol) : base(m => m.CryptoExchanges.ContainsKey(symbol))
        {
            ApplyOrderBy("MarketName");
        }
    }
}