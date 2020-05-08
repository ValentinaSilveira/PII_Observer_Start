using System;

namespace Observer
{
    public class TemperatureReporter : IObserver
    {
        private bool first;
        private Temperature last;
        private IObservable provider;

        public void StartReport(IObservable provider)
        {
            this.provider = provider;
            this.first = true;
            this.provider.Subscribe(this);
        }

        public void StopReport()
        {
            this.provider.UnSubscribe(this);
        }

        public void Update()
        {
            Console.WriteLine($"The temperature is {this.provider.Current.Degrees}°C at {this.provider.Current.Date:g}");
            if (first)
            {
                last = this.provider.Current;
                first = false;
            }
            else
            {
                Console.WriteLine($"   Change: {this.provider.Current.Degrees - last.Degrees}° in " +
                    $"{this.provider.Current.Date.ToUniversalTime() - last.Date.ToUniversalTime():g}");
            }
        }
    }
}
