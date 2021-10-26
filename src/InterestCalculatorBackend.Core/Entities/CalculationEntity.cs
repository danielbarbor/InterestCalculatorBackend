using System;
using System.Globalization;

namespace InterestCalculatorBackend.Core.Entities
{
    public class CalculationEntity
    {
        private double InitialValue { get; set; }
        
        private int Months { get; set; }
        
        private double ResultValue { get; set; }

        public CalculationEntity(double initialValue, int months)
        {
            InitialValue = initialValue;
            Months = months;
            DomainCultureRules.SetDomainCultureRules();
        }

        public double Calculate(double interest)
        {
            ResultValue = InitialValue * Math.Pow(1 + interest, Months);
            
            ResultValue = Math.Truncate(100 * ResultValue);
            
            ResultValue /= 100;

            return ResultValue;
        }

        public override string ToString()
        {
            return ResultValue.ToString("###########0.00");
        }

    }
}