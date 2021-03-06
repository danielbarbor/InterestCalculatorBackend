using InterestCalculatorBackend.Core.Entities;
using Xunit;

namespace InterestCalculatorBackend.Core.Test.Entities
{
    public class CalculationEntityTest
    {
        private readonly CalculationEntity _calculation;
        
        public CalculationEntityTest()
        {
            _calculation = new CalculationEntity(1000, 12);
        }
        
        [Fact]
        public void CalculateOperationTest()
        {
            var result = _calculation.Calculate(0.01);
            
            Assert.Equal(1126.82, result);
        }
        
        [Fact]
        public void CalculateOperationAndFormatTest()
        {
            var calculationFormatTest = new CalculationEntity(100, 5);
            var result = calculationFormatTest.Calculate(0.01);
            var resultString = calculationFormatTest.ToString();
            
            Assert.Equal(105.10, result);
            Assert.Equal("105,10", resultString);
        }
        
        [Fact]
        public void CalculateOperationToStringTest()
        {
            _calculation.Calculate(0.01);

            var resultString = _calculation.ToString();
            
            Assert.Equal("1126,82", resultString);
        }
    }
}