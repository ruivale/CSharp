using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZoneArticles.ObserverDesignPattern
{
    public class Stock
    {
        public string Name { get; set; }
        public double OpeningPrice { get; set; }
        public double ClosingPrice { get; set; }

        public Stock(string name, double open, double close)
        {
            this.Name = name;
            this.OpeningPrice = open;
            this.ClosingPrice = close;
        }
    }
}
