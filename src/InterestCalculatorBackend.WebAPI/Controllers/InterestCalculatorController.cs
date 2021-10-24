using System;
using System.Threading.Tasks;
using InterestCalculatorBackend.Abstractions.Application;
using InterestCalculatorBackend.Application.DTOs;
using InterestCalculatorBackend.Application.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace InterestCalculatorBackend.WebAPI.Controllers
{
    public class InterestCalculatorController : ControllerBase
    {
        private readonly ILogger<SourceCodeController> _logger;

        private readonly IConfiguration _configuration;

        private readonly IInterestCalculatorService<InputValueDto, OutputValueDto> _calculatorService;

        private readonly InputValueDtoValidator _validator;

        public InterestCalculatorController(ILogger<SourceCodeController> logger, IConfiguration configuration, IInterestCalculatorService<InputValueDto, OutputValueDto> calculatorService)
        {
            _logger = logger;
            _configuration = configuration;
            _calculatorService = calculatorService;
            _validator = new InputValueDtoValidator();

        }
        
        [HttpGet("/calculajuros")]
        public async Task<ActionResult<OutputValueDto>> GetInterestCalculation(double valorinicial, int meses)
        {
            try
            {
                var inputDto = new InputValueDto(valorinicial, meses);

                var validation = _validator.Validate(inputDto);

                if (!validation.IsValid)
                {
                    return BadRequest(validation.Errors);
                }
                
                // Getting info about interest rate server from appsettings. The user could maybe define another host.
                var interestRateHost = _configuration.GetSection("InterestRateApiHost").Value;

                var result = await _calculatorService.CalculateCompoundInterestAsync(interestRateHost, inputDto);

                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"A error has occured while attending the request, {e.Message}");
                return StatusCode(500, e.Message);
            }
        }
    }
}