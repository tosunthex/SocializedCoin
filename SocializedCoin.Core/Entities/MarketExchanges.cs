using System;
using System.Collections.Generic;

namespace SocializedCoin.Core.Entities
{
    public class MarketExchanges : BaseEntity
    {
        public string MarketName { get; set; }
        public IReadOnlyDictionary<string,IReadOnlyList<string>> CryptoExchanges { get; set; }
        public DateTime RecordDate { get; set; }
    }
}