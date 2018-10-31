using System;

namespace SocializedCoin.Api.Model
{
    public class CryptoList
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public Uri Logo { get; set; }
        public long Rank { get; set; }
    }
}