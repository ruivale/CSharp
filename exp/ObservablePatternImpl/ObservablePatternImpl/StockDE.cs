using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZoneArticles.ObserverUsingDelegatesAndEvents
{
    public class Stock
    {
        //declare a delegate for the event
        public delegate void AskPriceDelegate(object aPrice);
        //declare the event using the delegate
        public event AskPriceDelegate AskPriceChanged;

        //instance variable for ask price
        object _askPrice;

        //property for ask price
        public object AskPrice
        {
            set
            {
                //set the instance variable
                _askPrice = value;

                //fire the event
                AskPriceChanged(_askPrice);
            }

        }//AskPrice property
    }
}
