using System;
using System.Threading.Tasks;
using CryptoCompare_Api.Models.Responses.Other;
using MongoDB.Driver;
using SocilizedCoin.CryptoCompare.Data;

namespace SocilizedCoin.CryptoCompare.Repository
{
    public class SocialstatsRepository:ISocialstatsRepository
    {
        private readonly CryptoCompareContext _context = null;
        public SocialstatsRepository()
        {
            _context = new CryptoCompareContext();
        }
        public async Task AddSocialStat(SocialstatData socialstatData)
        {
            try
            {
                await _context.SocialStatCollection().InsertOneAsync(socialstatData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;    
            }
        }

        
        public async Task<SocialstatData> GetSocialstatDataBySymbol(string symbol)
        {
            return await _context.SocialStatCollection().Find(ssdata => ssdata.General.Name == symbol).FirstOrDefaultAsync();
        }
    }
}