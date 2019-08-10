using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveProgramming
{
    public class KeyInterfaces
    {
        public static void Main()
        {
            var observable = new Observable();
            var observer = new Observer();

            observable.Subscribe(observer);

            foreach(var i in Enumerable.Range(1, 20))
            {
                observable.Number = i;
            }
        }
    }

    public class Observable : IObservable<float>
    {
        private IObserver<float> observer;
        private int number;
        private int count = 0;
        public int Number
        {
            get { return number; }
            set
            {
                if (value == 123)
                {
                    observer.OnError(new Exception("invalid number"));
                }
                if (count == 10)
                {
                    observer.OnCompleted();
                }
                if (count++ < 10)
                {
                    observer.OnNext(number = value);
                }
            }
        }

        public IDisposable Subscribe(IObserver<float> observer)
        {
            this.observer = observer;
            return null;
        }
    }

    public class Observer : IObserver<float> // no need for nuget
    {
        // OnNext* -> (OnError | OnCompleted)?

        public void OnNext(float value)
        {
            Console.WriteLine($"Market sent us {value}");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"We failed due to {error}");
        }

        public void OnCompleted()
        {
            Console.WriteLine($"Market is closed");
        }
    }
}
