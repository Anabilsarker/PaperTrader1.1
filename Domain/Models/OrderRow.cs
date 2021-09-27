using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class OrderRow
    {
        public int Order_Id = 0;
        public string Account_Id = "";
        public string User_Id = "" ;
        public string Exch_Segment = "";
        public string Product_type = "";
        public string Buy_Sell = "";
        public string Trading_Symbol ="";
        public DateTime Expiry_Date = default(DateTime);
        public string Option_Type = "";
        public double Strike_Price = 0;
        public int Total_Qty = 0;
        public double Price = 0;
        public double Trigger_Price = 0;
        public int Pending_Qty = 0;
        public double Average_Price = 0;
        public string Status = "";
        public string Rejection_Reason = "";
        public string BWL = "";
        public int Nest_Order_No =0;
        public int Ref_Order_No = 0;
        public string Order_Source = "";
        public DateTime Nest_Update_Time = default(DateTime);
        public int Exchange_Order_No = 0;
        public string Order_Gen_Type = "";
        public int Traded_Qty = 0;
        public bool Modified_By_User = false;
        public string Order_Type = "";
    }
}
