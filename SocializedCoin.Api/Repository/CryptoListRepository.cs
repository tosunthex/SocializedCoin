using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public class CryptoListRepository : ICryptoListRepository
    {
        private readonly ILatestDataRepository _latestDataRepository;
        private readonly IGeneralDataRepository _generalDataRepository;

        public CryptoListRepository(IGeneralDataRepository generalDataRepository,
            ILatestDataRepository latestDataRepository)
        {
            _generalDataRepository = generalDataRepository;
            _latestDataRepository = latestDataRepository;
        }

        public async Task<IEnumerable<CryptoList>> Get()
        {
            var result = new List<CryptoList>();
            var generalData = await _generalDataRepository.Get();
            foreach (var data in generalData)
            {
                var cryptoCurrencyInfoData = data.CryptoCurrencyInfoData;
                var listingData = await _latestDataRepository.GetBySymbolFromDatabase(cryptoCurrencyInfoData.Symbol);

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