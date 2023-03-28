using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZoneArticles.ObserverDesignPattern
{
    public class StockMarket
    {
        public delegate void PriceChangeEventHandler(object sender, StockDetailsEventArgs e);
        public event PriceChangeEventHandler PriceChangedEvent;
        private Stock stock { get; set; }

        public StockMarket(Stock s)
        {
            this.stock = s;
        }

        /// <summary>
        /// method used to trigger the start of trading
        /// </summary>
        public void Start()
        {
            //make sure a stock is provided, otherwise throw an error
            if (stock == null)
                throw new ArgumentException("A stock must be provided before you can start trading");
            else
            {
                //get the current price of the stock being watched
                double currentPrice = this.stock.OpeningPrice;

                //simulate the price of the stock falling in the market
                //our notification will let the investor know when
                //it's time to buy
                while (currentPrice > stock.ClosingPrice)
                {
                    //simulate price dropping by $1 at a time
                    currentPrice -= 1.00;

                    //trigger our event so the Observer will know
                    OnStockPriceChanged(currentPrice);

                    //simply to make it drop lower (for demonstrating this example)
                    System.Threading.Thread.Sleep(2000);
                }
            }
        }

        /// <summary>
        /// our price change event
        /// </summary>
        /// <param name="current">current price of the stock when the event is triggered</param>
        protected void OnStockPriceChanged(double current)
        {
            if (PriceChangedEvent != null)
            {
                //create an instance of our event args
                StockDetailsEventArgs e = new StockDetailsEventArgs();

                //set the current price of the stock
                e.StockCurrentPrice = current;

                //display the current price
                Console.WriteLine(string.Format("{0}'s current stock price is now {1:C}", this.stock.Name, e.StockCurrentPrice));

                //now raise the price changed event
                PriceChangedEvent(this, e);
            }
        }

        public void AttachEvent(IObserve observe)
        {
            this.PriceChangedEvent += new PriceChangeEventHandler(observe.StockPriceChanged);
        }
    }
}
