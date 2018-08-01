using System;
using System.Threading;
using System.Threading.Tasks;
using CoinMarketCap;
using Microsoft.Extensions.Hosting;
using Socilizedcoin.CoinMarketCap.Model;
using Socilizedcoin.CoinMarketCap.Repository;

namespace Socilizedcoin.CoinMarketCap.Services
{
    public class TickerService:BackgroundService
    {
        private readonly ITickerRepository _tickerRepository;
        private readonly CoinMarketCapClient _coinMarketCapClient;
        
        public TickerService(ITickerRepository tickerRepository)
        {
            _tickerRepository = tickerRepository;
            _coinMarketCapClient = CoinMarketCapClient.Instance;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var dateTime = DateTime.Now;
                var tickersData = await _coinMarketCapClient.Ticker.GetTickers();
                var ticker = new MongoTicker
                {
                    Data = tickersData.Data,
                    TickerMetadata = tickersData.TickerMetadata,
                    RecordDateTime = dateTime
                };
                await _tickerRepository.AddTicker(ticker);
                await Task.Delay(TimeSpan.FromHours(4));
            }
        }
    }
}