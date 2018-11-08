using System.Net.Http;
using CoinMarketCapPro_API.Clients;
using CoinMarketCapPro_API.Parameters;

namespace SocializedCoin.Api.Parameters
{
    public static class CoinMarketCapConnection
    {
        public static ICoinMarketCapClient Create()
        {
            return new CoinMarketCapClient(new HttpClientHandler(), ApiEnvironment.Pro,
                "c572865c-d03a-4be2-8cba-84c963e48869");
        }
    }
}