namespace InterestCalculatorBackend.Application.DTOs
{
    public class InputValueDto
    {
        public double InitialValue { get; set; }
        
        public int Months { get; set; }

        public InputValueDto()
        {
            
        }

        public InputValueDto(double initialValue, int months)
        {
            InitialValue = initialValue;
            Months = months;
        }
    }
}