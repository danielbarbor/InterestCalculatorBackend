using System.Threading.Tasks;

namespace InterestCalculatorBackend.Abstractions.Application
{
    public interface IInterestCalculatorService<T, U>
    {
        Task<U> CalculateCompoundInterestAsync(T inputValue);
    }
}