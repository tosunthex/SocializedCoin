using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocializedCoin.Api.Parameters;
using SocializedCoin.Core.Entities;
using SocializedCoin.Core.Interfaces;
using SocializedCoin.Core.Specifications;
using SocializedCoin.Infrastructure.Data;

namespace SocializedCoin.Api.Repository
{
    public class CryptoListRepository : ICryptoListRepository
    {
        //private readonly ILatestDataRepository _latestDataRepository;
        //private readonly IGeneralDataRepository _generalDataRepository;
        private readonly IAsyncRepository<GeneralData> _generalDataRepository;
        private readonly IAsyncRepository<CoinMarketCapLatestData> _coinmarketcapLatestData;
        
        public CryptoListRepository(
            ILatestDataRepository latestDataRepository)
        {
            //_latestDataRepository = latestDataRepository;
            _generalDataRepository = new MongoRepository<GeneralData>();
            _coinmarketcapLatestData = new MongoRepository<CoinMarketCapLatestData>();
        }

        public async Task<IEnumerable<CryptoList>> Get()
        {
            var result = new List<CryptoList>();
            var generalData = await _generalDataRepository.ListAllAsync();
            foreach (var data in generalData)
            {
                var cryptoCurrencyInfoData = data.CryptoCurrencyInfoData;
                var latestDataSpec = new CoinMarketCapLatestDataFilterSpecification(cryptoCurrencyInfoData.Symbol);
                var listingData = await _coinmarketcapLatestData.GetBySpecAsync(latestDataSpec);
                //var listingData = await _latestDataRepository.GetBySymbolFromDatabase(cryptoCurrencyInfoData.Symbol);

                result.Add(new CryptoList
                {
                    Logo = cryptoCurrencyInfoData.Logo,
                    Name = cryptoCurrencyInfoData.Name,
                    Rank = listingData.ListingLatestData.CmcRank,
                    Symbol = cryptoCurrencyInfoData.Symbol
                });
            }

            return (from r in result
                orderby r.Rank
                select r);
        }
    }
}