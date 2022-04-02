namespace Strategy.Contracts
{
    public interface IStrategy
    {
        decimal Compute(decimal price);
    }
}
