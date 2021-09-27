using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum WatchRowColumns
    {
        ExchangeInstrumentId,
        TradingSymbol,
        BidQty,
        BidPrice,
        AskPrice,
        AskQty,
        LTP,
        PercentChange,
        ATP,
        Volume,
        Open,
        High,
        Low,
        PreClose
    }

    public enum NetPostionColumns
    {
        Account_Id,
        Account_Name,
        Exch_Segment,
        Symbol,
        Instrument_Name,
        Option_Type,
        Net_Buy_Value,
        Net_Sell_Value,
        Net_Value,
        Net_Buy_Qty,
        Net_Sell_Qty,
        Net_Qty,
        BEP,
        Sell_Avg_Price,
        Buy_Avg_Price,
        Last_Traded_Price,
        MTM,
        Realized_MTM,
        Unrealized_MTM,
        El_MTM,
        Trading_Symbol,
        Client_Context,
        Series_Expity,
        Strike_Price
    }

    public enum OrdersColumns
    {
        Order_Id,
        Account_Id,
        User_Id,
        Exch_Segment,
        Product_type,
        Buy_Sell,
        Trading_Symbol,
        Expiry_Date,
        Option_Type,
        Strike_Price,
        Total_Qty,
        Price,
        Trigger_Price,
        Pending_Qty,
        Average_Price,
        Status, 
        Rejection_Reason,
        BWL,
        Nest_Order_No,
        Ref_Order_No,
        Order_Source,
        Nest_Update_Time,
        Exchange_Order_No,
        Order_Gen_Type,
        Traded_Qty,
        Modified_By_User,
        Order_Type
    }
}
