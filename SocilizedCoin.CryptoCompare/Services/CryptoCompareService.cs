using System;
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
        private readonly ICoinlistRepository _coinlistRepository;
        private readonly CryptoCompareClient _client;

        public CryptoCompareService()
        {
            _client = CryptoCompareClient.Instance;
            _coinlistRepository = new CoinlistReposity();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var dateTime = DateTime.Now;
                var coinlist = await _client.OtherClient.GetCoinList();
                foreach (var coin in coinlist.Data.Values)
                {
                    var coindata = new CoinlistData
                    {
                        Id = coin.Id,
                        Url = coin.Url,
                        ImageUrl = coin.ImageUrl,
                        Name = coin.Name,
                        Symbol = coin.Symbol,
                        CoinName = coin.CoinName,
                        FullName = coin.FullName,
                        Algorithm = coin.Algorithm,
                        ProofType = coin.ProofType,
                        FullyPremined = coin.FullyPremined,
                        TotalCoinSupply = coin.TotalCoinSupply,
                        BuiltOn = coin.BuiltOn,
                        SmartContractAddress = coin.SmartContractAddress,
                        PreMinedValue = coin.PreMinedValue,
                        TotalCoinsFreeFloat = coin.TotalCoinsFreeFloat,
                        SortOrder = coin.SortOrder,
                        Sponsored = coin.Sponsored,
                        IsTrading = coin.IsTrading,
                        RecordDateTime = dateTime
                    };
                    await _coinlistRepository.AddCoinlistData(coindata);
                }
                
                //var socialStatdata = await _client.OtherClient.GetSocialStat(1182);
                //await _socialstatsRepository.AddSocialStat(socialStatdata);
                await Task.Delay(TimeSpan.FromHours(4));
            }
        }
    }
}