using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZoneArticles.ObserverDesignPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            //create a new stock isntance
            Stock s = new Stock("DZone", 15.00, 9.00);

            //provide our stock market instance know the stock
            StockMarket market = new StockMarket(s);

            //create 2 new investors, the price they'll buy at and what
            //stock they're watching
            IObserve Richard = new Investor("Richard", 11.00, s);
            IObserve Lyndsey = new Investor("Lyndsey", 9.50, s);

            //attach events to the stock market, so it can notify the investor
            //this uses the Observe pattern with delegates & events
            market.AttachEvent(Richard);
            market.AttachEvent(Lyndsey);

            //start the stock market
            market.Start();

            Console.WriteLine("\n\nPress any key to exit ...");
            Console.ReadKey();
        }
    }
}
