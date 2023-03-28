using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZoneArticles.ObserverUsingDelegatesAndEvents
{
    class ObserverUsingDelegatesAndEvents
    {
        public static void Main()
        {
            //create new display and stock instances
            StockDisplay stockDisplay = new StockDisplay();
            Stock stock = new Stock();

            //create a new delegate instance and bind it
            //to the observer's askpricechanged method
            Stock.AskPriceDelegate aDelegate = new Stock.AskPriceDelegate(stockDisplay.AskPriceChanged);

            //add the delegate to the event
            stock.AskPriceChanged += aDelegate;

            //loop 100 times and modify the ask price
            for (int looper = 0; looper < 100; looper++)
            {
                stock.AskPrice = looper;
            }

            //remove the delegate from the event
            stock.AskPriceChanged -= aDelegate;

            Console.WriteLine("\n\nPress any key to exit ...");
            Console.ReadKey();

        }//Main
    }
}
