using System;
using System.Threading.Tasks;
using InterestCalculatorBackend.Abstractions.Application;
using InterestCalculatorBackend.Application.DTOs;
using InterestCalculatorBackend.Core.Entities;

namespace InterestCalculatorBackend.Application.Services
{
    public class InterestCalculatorService : IInterestCalculatorService<InputValueDto, OutputValueDto>
    {
        private readonly IInterestRateService _interestRateService;
        
        public InterestCalculatorService(IInterestRateService interestRateService)
        {
            _interestRateService = interestRateService;
        }
        
        public async Task<OutputValueDto> CalculateCompoundInterestAsync(string hostToConsult, InputValueDto inputValue)
        {
            var rate = await _interestRateService.GetInterestRateNowAsync(hostToConsult);

            var calculation = new CalculationEntity(inputValue.InitialValue, inputValue.Months);

            var result = calculation.Calculate(rate);

            return new OutputValueDto(result, calculation.ToString());

        }
    }
}