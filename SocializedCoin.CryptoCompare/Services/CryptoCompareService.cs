using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CryptoCompare_Api.Clients;
using CryptoCompare_Api.Models.Responses.Other;
using Microsoft.Extensions.Hosting;
using SocilizedCoin.CryptoCompare.Model;
using SocilizedCoin.CryptoCompare.Repository;
using CoinlistData = SocilizedCoin.CryptoCompare.Model.CoinlistData;

namespace SocilizedCoin.CryptoCompare.Services
{
    public class CryptoCompareService:BackgroundService
    {
        private readonly IExchangeRepository _exchangeRepository;
        private readonly CryptoCompareClient _client;

        public CryptoCompareService()
        {
            _client = CryptoCompareClient.Instance;
            _exchangeRepository = new ExchangeRepository();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var dateTime = DateTime.Now;
                    var marketList = await _client.OtherClient.GetAllExchanges();
                    var importantMarkets = new[] {"Binance", "Bitfinex","Cexio","Coinbase"};
                    foreach (var market in marketList)
                    {
                        if (!importantMarkets.Contains(market.Key)) continue;
                        var exchangeData = new MarketCryptoExchanges
                        {
                            MarketName = market.Key,
                            CryptoExchanges = market.Value,
                            RecordDate = dateTime
                        };
                        await _exchangeRepository.AddExchange(exchangeData);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }                
                
                //var socialStatdata = await _client.OtherClient.GetSocialStat(1182);
                //await _socialstatsRepository.AddSocialStat(socialStatdata);
                await Task.Delay(TimeSpan.FromHours(4));
            }
        }
    }
}