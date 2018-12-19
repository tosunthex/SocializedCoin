using System;

namespace SocializedCoin.Core.Entities
{
    public class CryptoList:BaseEntity
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public Uri Logo { get; set; }
        public long Rank { get; set; }
    }
}