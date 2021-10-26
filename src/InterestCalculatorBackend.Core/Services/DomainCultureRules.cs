using System.Globalization;

namespace InterestCalculatorBackend.Core
{
    public class DomainCultureRules
    {
        public static CultureInfo GetDomainCultureRules()
        {
            var culture = new CultureInfo("pt-BR");
            culture.NumberFormat.NumberDecimalSeparator = ",";
            culture.NumberFormat.NumberGroupSeparator = ".";
            culture.NumberFormat.CurrencyDecimalSeparator = ",";
            culture.NumberFormat.CurrencyGroupSeparator = ".";

            return culture;
        }
    }
}