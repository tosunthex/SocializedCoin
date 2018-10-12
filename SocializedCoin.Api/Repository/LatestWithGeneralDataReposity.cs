using System.Collections.Generic;
using System.Threading.Tasks;
using SocializedCoin.Api.Data;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public class LatestWithGeneralDataReposity:ILatestWithGeneralDataReposity
    {
        private readonly ILatestDataReposity _latestDataReposity;
        private readonly IGeneralDataReposity _generalDataReposity;
        private readonly CoinMarketCapContext _context = null;
        
        public LatestWithGeneralDataReposity(ILatestDataReposity latestDataReposity,
            IGeneralDataReposity generalDataReposity)
        {
            _latestDataReposity = latestDataReposity;
            _generalDataReposity = generalDataReposity;
            _context = new CoinMarketCapContext();
        }
        public async Task<IEnumerable<LatestWithGeneralData>> Get()
        {
            var result = new List<LatestWithGeneralData>();
            var generalData = await _generalDataReposity.Get();
            foreach (var data in generalData)
            {
                var cryptoCurrencyInfoData = data.CryptoCurrencyInfoData;
                var listingData = await _latestDataReposity.GetById(cryptoCurrencyInfoData.Id);
                 
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
            var generalData = await _generalDataReposity.GetBySymbol(symbol);
            var latestData = await _latestDataReposity.GetBySymbol(symbol);
            return new LatestWithGeneralData
            {
                CryptoCurrencyInfoData = generalData.CryptoCurrencyInfoData,
                ListingLatestData = latestData.ListingLatestData
            };
        }

        public async Task<LatestWithGeneralData> GetById(long id)
        {
            var generalData = await _generalDataReposity.GetById(id);
            var latestData = await _latestDataReposity.GetById(id);
            return new LatestWithGeneralData
            {
                CryptoCurrencyInfoData = generalData.CryptoCurrencyInfoData,
                ListingLatestData = latestData.ListingLatestData
            };
        }
    }
}