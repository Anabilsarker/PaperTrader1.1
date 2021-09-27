using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAccess
{
    public static class Data1
    {
        public static int instrumentId;
        public static string TradingSymbol { get; set; }
        public static int BidQty { get; set; }
        public static double BidPrice { get; set; }
        public static double AskPrice { get; set; }
        public static int AskQty { get; set; }
        public static double LTP { get; set; }
        public static double PercentChange { get; set; }
        public static double ATP { get; set; }
        public static double Volume { get; set; }
        public static double Open { get; set; }
        public static double High { get; set; }
        public static double Low { get; set; }
        public static double Close { get; set; }
        public static double PreClose { get; set; }
    }
}
