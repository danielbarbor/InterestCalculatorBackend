using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InterestCalculatorBackend.InterestRateAPI.Controllers
{
    [ApiController]
    public class InterestRateController : ControllerBase
    {
        private readonly ILogger<InterestRateController> _logger;

        private const double Rate = 0.01;

        public InterestRateController(ILogger<InterestRateController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Informs the current interest rate in the system
        /// </summary>
        /// <returns>A double with the interest rate decimal value</returns>
        [HttpGet("/taxaJuros")]
        public ActionResult<string> GetInterestRateNow()
        {
            _logger.LogInformation("Request for rate received");
            _logger.LogInformation("Sending rate");
            
            return Rate.ToString(GetDomainCultureRules());
        }

        private CultureInfo GetDomainCultureRules()
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