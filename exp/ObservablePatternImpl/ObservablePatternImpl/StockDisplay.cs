using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZoneArticles.ObserverUsingDelegatesAndEvents
{
    public class StockDisplay
    {

        public void AskPriceChanged(object aPrice)
        {
            Console.Write("The new ask price is:" + aPrice + "\r\n");
        }

    }//StockDispslay class
}
