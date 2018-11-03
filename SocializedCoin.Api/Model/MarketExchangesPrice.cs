using System;
using System.Collections.Generic;
using CryptoCompare_Api.Models.Responses.Price;

namespace SocializedCoin.Api.Model
{
    public class MarketExchangesPrice
    {
        public string MarketName { get; set; }
        public Dictionary<string,DisplayCryptoData> MultipleSymbolFullData { get; set; }
    }
}