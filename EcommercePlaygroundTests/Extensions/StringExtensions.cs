using System.Globalization;

namespace EcommercePlaygroundTests.Extensions
{
    public static class StringExtensions
    {
        private static readonly NumberFormatInfo NumberFormat = new NumberFormatInfo()
        {
            CurrencySymbol = "$",
            CurrencyGroupSeparator = ",",
            CurrencyDecimalSeparator = ".",
        };

        public static decimal? CurrencyToDecimal(this string text)
        {
            return decimal.Parse(text, NumberStyles.Currency, NumberFormat);
        }

        public static decimal? TryCurrencyToDecimal(this string text)
        {
            return decimal.TryParse(text, NumberStyles.Currency, NumberFormat, out var result)
                ? result
                : null;
        }
    }
}
