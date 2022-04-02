namespace Observer.Contracts
{
    public interface IObserver
    {
        void Update(decimal propertyTax, decimal ttpTax);
    }
}
