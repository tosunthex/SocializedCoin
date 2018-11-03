using System.Threading.Tasks;
using CryptoCompare_Api.Models.Responses.Other;

namespace SocializedCoin.CryptoCompare.Repository
{
    public interface ISocialstatsRepository
    {
        Task AddSocialStat(SocialstatData socialstatData);
        Task<SocialstatData> GetSocialstatDataBySymbol(string symbol);
    }
}