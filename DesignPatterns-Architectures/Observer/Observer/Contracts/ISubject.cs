namespace Observer.Contracts
{
    public interface ISubject
    {
        void Subscribe(IObserver o);

        void Unsubscribe(IObserver o);

        void Notify();
    }
}
