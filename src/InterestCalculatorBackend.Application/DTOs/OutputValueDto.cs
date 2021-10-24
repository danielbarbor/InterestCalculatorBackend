using System.Globalization;

namespace InterestCalculatorBackend.Application.DTOs
{
    public class OutputValueDto
    {
        public double ResultValue { get; set; }
        
        public string ResultRepresentation { get; set; }

        public OutputValueDto()
        {
            
        }

        public OutputValueDto(double resultValue)
        {
            ResultValue = resultValue;
            ResultRepresentation = resultValue.ToString(CultureInfo.InvariantCulture);
        }

        public OutputValueDto(double resultValue, string resultRepresentation)
        {
            ResultValue = resultValue;
            ResultRepresentation = resultRepresentation;
        }
    }
}