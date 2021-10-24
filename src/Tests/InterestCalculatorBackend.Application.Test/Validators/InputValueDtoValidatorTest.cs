using InterestCalculatorBackend.Application.DTOs;
using InterestCalculatorBackend.Application.Validators;
using Xunit;

namespace InterestCalculatorBackend.Application.Test.Validators
{
    public class InputValueDtoValidatorTest
    {
        private readonly InputValueDtoValidator _validator;
        
        public InputValueDtoValidatorTest()
        {
            _validator = new InputValueDtoValidator();
        }

        [Fact]
        public void ValidateInputValueDtoWithoutErrors()
        {
            var inputValueDto = new InputValueDto(1000, 12);
            
            var validationResult = _validator.Validate(inputValueDto);
            
            Assert.True(validationResult.IsValid);
        }
        
        [Fact]
        public void ValidateInputValueDtoWithInvalidValue()
        {
            var inputValueDto = new InputValueDto(0, 12);
            
            var validationResult = _validator.Validate(inputValueDto);
            
            Assert.False(validationResult.IsValid);
            Assert.Single(validationResult.Errors);
            Assert.Equal("The minimal value must be greater than 0", validationResult.Errors[0].ErrorMessage);
        }
        
        [Fact]
        public void ValidateInputValueDtoWithInvalidMonth()
        {
            var inputValueDto = new InputValueDto(1000, 0);
            
            var validationResult = _validator.Validate(inputValueDto);
            
            Assert.False(validationResult.IsValid);
            Assert.Single(validationResult.Errors);
            Assert.Equal("The minimal month count must be greater than 0", validationResult.Errors[0].ErrorMessage);
        }
        
        [Fact]
        public void ValidateInputValueDtoWithBothValuesInvalid()
        {
            var inputValueDto = new InputValueDto(0, 0);
            
            var validationResult = _validator.Validate(inputValueDto);
            
            Assert.False(validationResult.IsValid);
            Assert.Equal(2, validationResult.Errors.Count);
        }
    }
}