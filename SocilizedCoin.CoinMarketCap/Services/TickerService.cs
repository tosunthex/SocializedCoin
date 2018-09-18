using System;
using System.Threading;
using System.Threading.Tasks;
using CoinMarketCap;
using CryptoCompare_Api.Clients;
using Microsoft.Extensions.Hosting;
using SocilizedCoin.CoinMarketCap.Model;
using SocilizedCoin.CoinMarketCap.Repository;

namespace SocilizedCoin.CoinMarketCap.Services
{
    public class TickerService:BackgroundService
    {
        private readonly CoinMarketCapClient _coinMarketCapClient;
        private readonly CryptoCompareClient _cryptoCompareClient;
        private readonly ITickerRepository _tickerRepository;
        private readonly ICoinlistRepository _coinlistRepository;
        
        public TickerService(
            ITickerRepository tickerRepository, 
            ICoinlistRepository coinlistRepository)
        {
            _tickerRepository = tickerRepository;
            _coinlistRepository = coinlistRepository;
            _coinMarketCapClient = CoinMarketCapClient.Instance;
            _cryptoCompareClient = CryptoCompareClient.Instance;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var dateTime = DateTime.Now;
                var tickersData = await _coinMarketCapClient.Ticker.GetTickers();
                foreach (var ticker in tickersData.Data.Values)
                {
                    var cryptoId = await _coinlistRepository.GetCoinlistDataBySymbol(ticker.Symbol) ??
                                   await _coinlistRepository.GetCoinlistDataByCoinName(ticker.Name) ;

                    var socialstatdata = cryptoId != null ? await _cryptoCompareClient.OtherClient.GetSocialStat(cryptoId.Id) : null;
                    var mongoTicker = new TickerWithSocialData
                    {
                        Id = ticker.Id,
                        Name = ticker.Name,
                        Symbol = ticker.Symbol,
                        WebsiteSlug = ticker.WebsiteSlug,
                        Rank = ticker.Rank,
                        CirculatingSupply = ticker.CirculatingSupply,
                        TotalSupply = ticker.TotalSupply,
                        MaxSupply = ticker.MaxSupply,
                        Quotes = ticker.Quotes,
                        LastUpdated = ticker.LastUpdated,
                        RecordDateTime = dateTime,
                        SocialstatData = socialstatdata?.Data,
                    };
                    await _tickerRepository.AddTicker(mongoTicker);
                }
                await Task.Delay(TimeSpan.FromHours(4));
            }
        }
    }
}