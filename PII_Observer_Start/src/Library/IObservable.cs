using Observer;

public interface IObservable
{
    Temperature Current { get; }
    void Subscribe(IObserver observer);

    void UnSubscribe(IObserver observer);
}