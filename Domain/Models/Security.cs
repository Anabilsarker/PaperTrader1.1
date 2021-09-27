using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ApiProtocol.Base;

namespace Domain.Models
{
    public class Security
    {
        public ExchangeSegment exchangeSegment;
        public int exchangeInstrumentID;
        public int instrumentType;
        public string name;
        public string Description;
        public Series series;
        public string NameWithSeries;
        public long instrumentID;
        public double PriceBandHigh;
        public double PriceBandLow;
        public int freezeQty;
        public double tickSize;
        public int LotSize;
        public long UnderlyingInstrumentId;
        public string UnderlyingIndexName;
        public DateTime ContractExpiration;
        public double StrikePrice;
        public int OptionType;
    }
}
