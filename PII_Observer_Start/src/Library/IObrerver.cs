
public interface IObserver
{
    void StartReport(IObservable provider);

    void StopReport();

    void Update();
}
