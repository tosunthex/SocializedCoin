using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using SocializedCoin.Api.Data;
using SocializedCoin.Api.Model;

namespace SocializedCoin.Api.Repository
{
    public class GeneralDataRepository:IGeneralDataRepository
    {
        private readonly CoinMarketCapContext _context = null;
        public GeneralDataRepository()
        {
            _context = new CoinMarketCapContext();
        }
        public async Task<IEnumerable<GeneralData>> Get()
        {
           return await _context.GetCryptoCurrencyGeneralData().Find(_ => true).ToListAsync();
        }

        public async Task<GeneralData> GetById(long id)
        {
            return await _context.GetCryptoCurrencyGeneralData()
                .Find(ccid => ccid.CryptoCurrencyInfoData.Id == id).FirstOrDefaultAsync();
        }

        public async Task<GeneralData> GetBySymbol(string symbol)
        {
            return await _context.GetCryptoCurrencyGeneralData()
                .Find(ccid => ccid.CryptoCurrencyInfoData.Symbol == symbol).FirstOrDefaultAsync();
        }
    }
}