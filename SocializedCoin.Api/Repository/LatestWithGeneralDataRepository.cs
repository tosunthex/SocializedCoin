using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Api.Data;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public class LatestWithGeneralDataRepository:ILatestWithGeneralDataRepository
    {
        private readonly ILatestDataRepository _latestDataRepository;
        private readonly IGeneralDataRepository _generalDataRepository;
        private readonly CoinMarketCapContext _context = null;
        
        public LatestWithGeneralDataRepository(ILatestDataRepository latestDataRepository,
            IGeneralDataRepository generalDataReposity)
        {
            _latestDataRepository = latestDataRepository;
            _generalDataRepository = generalDataReposity;
            _context = new CoinMarketCapContext();
        }
        public async Task<IEnumerable<LatestWithGeneralData>> Get()
        {
            var result = new List<LatestWithGeneralData>();
            var generalData = await _generalDataRepository.Get();
            foreach (var data in generalData)
            {
                var cryptoCurrencyInfoData = data.CryptoCurrencyInfoData;
                var listingData = await _latestDataRepository.GetById(cryptoCurrencyInfoData.Id);
                 
                result.Add(new LatestWithGeneralData
                {
                    CryptoCurrencyInfoData = cryptoCurrencyInfoData,
                    ListingLatestData = listingData.ListingLatestData
                });
            }

            return result;
        }

        public async Task<LatestWithGeneralData> GetBySymbol(string symbol)
        {
            var generalData = await _generalDataRepository.GetBySymbol(symbol);
            var latestData = await _latestDataRepository.GetBySymbol(symbol);
            return new LatestWithGeneralData
            {
                CryptoCurrencyInfoData = generalData.CryptoCurrencyInfoData,
                ListingLatestData = latestData.ListingLatestData
            };
        }

        public async Task<LatestWithGeneralData> GetById(long id)
        {
            var generalData = await _generalDataRepository.GetById(id);
            var latestData = await _latestDataRepository.GetById(id);
            return new LatestWithGeneralData
            {
                CryptoCurrencyInfoData = generalData.CryptoCurrencyInfoData,
                ListingLatestData = latestData.ListingLatestData
            };
        }
    }
}