﻿using System.Collections.Generic;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Models.Responses;
using CoinMarketCapPro_API.Models.Responses.CryptoCurrency;
using CryptoCompare_Api.Models.Responses.Price;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public interface ILatestDataRepository
    {
        Task<ResponseMain<Dictionary<string, CryptoCurrencyInfoData>>> GetBySymbol(string symbol);
        Task<LatestCryptoCurrencyData> GetBySymbolFromDatabase(string symbol);
        Task<MultipleSymbolFullData> GetBySymbolAndMarketFromCryptoCompare(string fromSymbol,string toSymbol,string market);
    }
}