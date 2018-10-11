using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;
using Microsoft.Extensions.Hosting;
using SocilizedCoin.CoinMarketCap.Model;
using SocilizedCoin.CoinMarketCap.Repository;

namespace SocilizedCoin.CoinMarketCap.Services
{
    public class CoinMarketCapService:BackgroundService
    {
        private readonly CoinMarketCapClient _coinMarketCapClient;
        private readonly ICoinMarketCapRepository _coinMarketCapRepository;
        
        public CoinMarketCapService(ICoinMarketCapRepository coinMarketCapRepository)
        {
            _coinMarketCapRepository = coinMarketCapRepository;
            _coinMarketCapClient = new CoinMarketCapClient(new HttpClientHandler(), ApiEnvironment.Pro,"c572865c-d03a-4be2-8cba-84c963e48869");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var dateTime = DateTime.Now;
                var listingData = await _coinMarketCapClient.CryptoCurrencyClient.GetListingLatest(1, 100,
                    new[] {Currency.Usd}, SortField.MarketCap, SortDirection.Desc, CryptoCurrencyType.All);
                var cryptoIds = new List<string>();
                foreach (var listElement in listingData.Data)
                {
                    cryptoIds.Add(listElement.Id.ToString());
                    
                    var mongoTicker = new LatestCryptoCurrencyData
                    {
                        ListingLatestData = listElement,
                        RecordDateTime = dateTime
                    };
                    await _coinMarketCapRepository.AddTicker(mongoTicker);
                }

                var allCryptoCurrencyInfoData = await 
                    _coinMarketCapClient.CryptoCurrencyClient.GetMetaData(cryptoIds.ToArray(), new string[]{});

                foreach (var cryptoData in allCryptoCurrencyInfoData.Data)
                {
                    var mongoTicker = new CryptoCurrencyGeneralData
                    {
                        RecordDateTime = dateTime,
                        CryptoCurrencyInfoData = cryptoData.Value
                    };
                    await _coinMarketCapRepository.AddGeneralData(mongoTicker);
                }
                await Task.Delay(TimeSpan.FromMinutes(3));
            }
        }
    }
}