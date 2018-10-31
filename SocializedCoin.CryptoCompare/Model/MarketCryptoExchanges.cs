using System;
using System.Collections.Generic;

namespace SocilizedCoin.CryptoCompare.Model
{
    public class MarketCryptoExchanges
    {
        public string MarketName { get; set; }
        public IReadOnlyDictionary<string,IReadOnlyList<string>> CryptoExchanges { get; set; }
        public DateTime RecordDate { get; set; }
    }
}