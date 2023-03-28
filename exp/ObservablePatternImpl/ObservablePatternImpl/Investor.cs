using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZoneArticles.ObserverDesignPattern
{
    public class Investor : IObserve
    {
        private string Name { get; set; }
        private double BuyAt { get; set; }
        private Stock stock { get; set; }
        private bool bought = false;

        public Investor(string name, double price, Stock s)
        {
            this.Name = name;
            this.BuyAt = price;
            this.stock = s;
        }

        void IObserve.StockPriceChanged(object sender, StockDetailsEventArgs e)
        {
            //check if the current stock price is below this investors
            //buy price, if it is then buy it
            if (e.StockCurrentPrice <= this.BuyAt && !bought)
            {
                //have the investor buy the stock then mark bought as true so they dont buy it again
                Console.WriteLine(string.Format("{0} is buying {1}'s stock at {2:C}", Name, this.stock.Name, e.StockCurrentPrice));
                this.bought = true;
            }
        }
    }
}
