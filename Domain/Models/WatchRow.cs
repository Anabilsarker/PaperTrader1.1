using Domain.ApiProtocol.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class WatchRow: INotifyPropertyChanged
    {
        public ExchangeSegment exchangeSegment;
        public int instrumentId;

        public string TradingSymbol { get; set; }
        public int BidQty { get; set; }
        public double BidPrice { get; set; }
        public double AskPrice { get; set; }
        public int AskQty { get; set; }
        public double LTP { get; set; }
        public double PercentChange { get; set; }
        public double ATP { get; set; }
        public double Volume { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double PreClose { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
