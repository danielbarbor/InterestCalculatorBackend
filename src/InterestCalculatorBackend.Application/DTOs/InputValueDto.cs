namespace InterestCalculatorBackend.Application.DTOs
{
    public class InputValueDto
    {
        /// <summary>
        /// The initial value for calculation
        /// </summary>
        public double InitialValue { get; set; }
        
        /// <summary>
        /// The months, representing time
        /// </summary>
        public int Months { get; set; }

        public InputValueDto(double initialValue, int months)
        {
            InitialValue = initialValue;
            Months = months;
        }
    }
}