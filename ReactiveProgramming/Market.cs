using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactiveProgramming
{
    public class Market // observable
    {
        public BindingList<float> Prices = new BindingList<float>();

        public void AddPrice(float price)
        {
            Prices.Add(price);
        }

        public static void Main() // observer
        {
            Market market = new Market();
            market.AddPrice(1);
            market.Prices.ListChanged += (sender, eventArgs) => // Subscribe
            {
                if (eventArgs.ListChangedType == ListChangedType.ItemAdded)
                {
                    Console.WriteLine($"Added price {((BindingList<float>)sender)[eventArgs.NewIndex]}");
                }
            };
            market.AddPrice(2);
        }

        // Problems with this approach

        // 1) How do we know when a new item becomes available?

        // 2) how do we know when the market is done supplying items?
        // maybe you are trading a futures contract that expired and there will be no more prices

        // 3) What happens if the market feed is broken?
    }
}
