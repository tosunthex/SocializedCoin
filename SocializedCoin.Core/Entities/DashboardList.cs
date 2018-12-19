namespace SocializedCoin.Core.Entities
{
    public class DashboardList:BaseEntity
    {
        public DashboardListValues Values { get; set; }
        public DashBoardListDisplay Display { get; set; }
        public long CmcRank { get; set; }
        public string Symbol { get; set; }
        public string Name     { get; set; }
    }

    public class DashBoardListDisplay
    {
        public string MarketCap { get; set; }
        public string Price { get; set; }
        public string Volume24H { get; set; }
        public string PercentChange24H { get; set; }
        public string CirculatingSupply { get; set; }
    }

    public class DashboardListValues
    {
        public double? MarketCap { get; set; }
        public double? Price { get; set; }
        public double? Volume24H { get; set; }
        public double? PercentChange24H { get; set; }
        public double? CirculatingSupply { get; set; }
    }
}