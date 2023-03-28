using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DZoneArticles.ObserverDesignPattern
{
    public interface IObserve
    {
        void StockPriceChanged(object sender, StockDetailsEventArgs e);
    }
}
