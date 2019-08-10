using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reactive.Subjects;

namespace ReactiveProgramming
{
    public class ObserverOfT
    {
        public static void Main()
        {
            // subject class is both an observer and observable

            var simulatedMarket = new Subject<float>();
            var observer = new Observer();

            // note also the overloads of this!
            simulatedMarket.Subscribe(observer);
            simulatedMarket.OnNext(123);
            simulatedMarket.Subscribe(observer); // late subscription
            simulatedMarket.OnNext(456);
            simulatedMarket.OnCompleted();

            simulatedMarket.OnNext(321); // this will not work
            Console.WriteLine(simulatedMarket.HasObservers); // nope
        }
    }
}
