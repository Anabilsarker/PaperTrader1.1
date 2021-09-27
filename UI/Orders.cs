using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Orders : Form
    {
        string _formName;
        public Orders(string formName)
        {

            InitializeComponent();
            _formName = formName;
            AppDatabase.Inventory.Instance().PositionUpdateEvent += LoadOrders;
            GenerateColumns();
            LoadOrders();

            
        }

        void GenerateColumns()
        {
            foreach(var header in Enum.GetNames(typeof(Domain.Models.OrdersColumns)))
            {
                if (_formName.Contains("Close"))
                {
                    if (!(header.Contains("Trigger") || header.Contains("Pending")))
                    {
                        dataGridViewOrders.Columns.Add(header.Replace("_", "") + "Col", header.Replace("_", " "));
                    }
                }
                else if(_formName.Contains("Open"))
                {
                       dataGridViewOrders.Columns.Add(header.Replace("_", "") + "Col", header.Replace("_", " "));
                }
            }
        }

        void LoadOrders()
        {
            if (dataGridViewOrders.InvokeRequired)
            {
                Action safeWrite = delegate { LoadOrders(); };
                dataGridViewOrders.Invoke(safeWrite);

            }
            else
            {
                dataGridViewOrders.Rows.Clear();
                if (_formName.Contains("Open"))
                {
                    
                     foreach (var order in AppDatabase.Inventory.Instance().OpenOrders)
                     {
                        dataGridViewOrders.Rows.Add(order.Order_Id,order.Account_Id, order.User_Id, order.Exch_Segment, order.Product_type, order.Buy_Sell, order.Trading_Symbol, order.Expiry_Date, order.Option_Type, order.Strike_Price, order.Total_Qty, order.Price, order.Trigger_Price, order.Pending_Qty, order.Average_Price, order.Status, order.Rejection_Reason, order.BWL, order.Nest_Order_No, order.Ref_Order_No, order.Order_Source, order.Nest_Update_Time, order.Exchange_Order_No, order.Order_Gen_Type, order.Traded_Qty, order.Modified_By_User, order.Order_Type);
                    }
                }
                else
                {
                    
                    foreach (var order in AppDatabase.Inventory.Instance().ClosedOrders)
                    {


                        dataGridViewOrders.Rows.Add(order.Order_Id,order.Account_Id, order.User_Id, order.Exch_Segment, order.Product_type, order.Buy_Sell, order.Trading_Symbol, order.Expiry_Date, order.Option_Type, order.Strike_Price, order.Total_Qty, order.Price, order.Average_Price, order.Status, order.Rejection_Reason, order.BWL, order.Nest_Order_No, order.Ref_Order_No, order.Order_Source, order.Nest_Update_Time, order.Exchange_Order_No, order.Order_Gen_Type, order.Traded_Qty, order.Modified_By_User, order.Order_Type);
                        
                    }
                }
            }
            
        }

        private void dataGridViewOrders_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            string buySellIndicator = dataGridViewOrders.Rows[e.RowIndex].Cells[(int)OrdersColumns.Buy_Sell].Value.ToString();
            if (buySellIndicator == "Buy")
                dataGridViewOrders.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Green;
            else
                dataGridViewOrders.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
        }
    }
}
