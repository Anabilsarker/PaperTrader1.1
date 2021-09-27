using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class NetPositionRow
    {
        public string User_Id;
        public string Account_Id;
        public string Account_Name;
        public string Exch_Segment;
        public string Symbol;
        public string Instrument_Name;
        public string Option_Type;
        public double Net_Buy_Value;
        public double Net_Sell_Value;
        public double Net_Value;
        public int Net_Buy_Qty;
        public int Net_Sell_Qty;
        public int Net_Qty;
        public int BEP;
        public double Sell_Avg_Price;
        public double Buy_Avg_Price;
        public double Last_Traded_Price;
        public double MTM;
        public double Realized_MTM;
        public double Unrealized_MTM;
        public double El_MTM;
        public string Trading_Symbol;
        public string Client_Context;
        public DateTime Series_Expity;
        public double Strike_Price;

        /// <summary>
        /// Default
        /// </summary>
        public NetPositionRow()
        {

        }
        public NetPositionRow(
            string User_Id,
            string Account_Id,
            string Account_Name,
            string Exch_Segment,
            string Symbol,
            string Instrument_Name,
            string Option_Type,
            double Net_Buy_Value,
            double Net_Sell_Value,
            double Net_Value,
            int Net_Buy_Qty,
            int Net_Sell_Qty,
            int Net_Qty,
            int BEP,
            double Sell_Avg_Price,
            double Buy_Avg_Price,
            double Last_Traded_Price,
            double MTM,
            double Realized_MTM,
            double Unrealized_MTM,
            double El_MTM,
            string Trading_Symbol,
            string Client_Context,
            DateTime Series_Expity,
            double Strike_Price
        )
        {
            this.User_Id = User_Id;
            this.Account_Id = Account_Id;
            this.Account_Name = Account_Name;
            this.Exch_Segment = Exch_Segment;
            this.Symbol = Symbol;
            this.Instrument_Name = Instrument_Name;
            this.Option_Type = Option_Type;
            this.Net_Buy_Value = Net_Buy_Value;
            this.Net_Sell_Value = Net_Sell_Value;
            this.Net_Value = Net_Value;
            this.Net_Buy_Qty = Net_Buy_Qty;
            this.Net_Sell_Qty = Net_Sell_Qty;
            this.Net_Qty = Net_Qty;
            this.BEP = BEP;
            this.Sell_Avg_Price = Sell_Avg_Price;
            this.Buy_Avg_Price = Buy_Avg_Price;
            this.Last_Traded_Price = Last_Traded_Price;
            this.MTM = MTM;
            this.Realized_MTM = Realized_MTM;
            this.Unrealized_MTM = Unrealized_MTM;
            this.El_MTM = El_MTM;
            this.Trading_Symbol = Trading_Symbol;
            this.Client_Context = Client_Context;
            this.Series_Expity = Series_Expity;
            this.Strike_Price = Strike_Price;
        }

    
    }
}
