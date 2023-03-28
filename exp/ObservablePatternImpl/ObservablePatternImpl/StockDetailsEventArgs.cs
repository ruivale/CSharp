using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZoneArticles.ObserverDesignPattern
{
    public class StockDetailsEventArgs : EventArgs
    {
        public double StockCurrentPrice { get; set; }
    }
}
