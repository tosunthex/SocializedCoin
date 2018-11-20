using System.ComponentModel;
using System.Globalization;

namespace SocializedCoin.Api.Services
{
    public static class NumberConverter
    {
        private static readonly CultureInfo CultureInfo = CultureInfo.CreateSpecificCulture("en-US");
        
        public static string ConvertToPrice(double? value)
        {
            if (value != null)
                return value >= 1
                    ? ((double) value).ToString("C2", CultureInfo)
                    : ((double) value).ToString("C6", CultureInfo);
            
            return null;
        }

        public static string ConvertToPercent(double? value)
        {
            return value == null ? null : string.Format("{0} %", ((double) value).ToString("N2", CultureInfo));
        }

        public static string ConvertToNumber(double? value)
        {
            return value == null ? null : ((double) value).ToString("N2", CultureInfo);
        }
    }
}