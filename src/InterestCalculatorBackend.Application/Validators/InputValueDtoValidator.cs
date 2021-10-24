using FluentValidation;
using InterestCalculatorBackend.Application.DTOs;

namespace InterestCalculatorBackend.Application.Validators
{
    public class InputValueDtoValidator : AbstractValidator<InputValueDto>
    {
        public InputValueDtoValidator()
        {
            RuleFor(input => input.InitialValue).NotNull().GreaterThan(0).WithMessage("The minimal value must be greater than 0");
            RuleFor(input => input.Months).NotNull().GreaterThan(0).WithMessage("The minimal month count must be greater than 0");
        }
    }
}