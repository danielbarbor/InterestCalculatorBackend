namespace InterestCalculatorBackend.Abstractions.Application
{
    public interface ISourceCodeService<out T>
    {
        public T ShowMeTheCode();
    }
}