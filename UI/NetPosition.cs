using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain.Models;

namespace UI
{
    public partial class NetPosition : Form
    {
        public NetPosition()
        {
            InitializeComponent();
            AppDatabase.Inventory.Instance().UpdateNetPositionEvent += UpdateMTM;
        }

        public void UpdateMTM()
        {
            if (labelBQ.InvokeRequired)
            {
                Action safeWrite = delegate { UpdateMTM(); };
                labelBQ.Invoke(safeWrite);

            }
            else
            {
                foreach (var netPositionRow in AppDatabase.Inventory.Instance().NetPosition)
                {
                    WatchRow watchRow = AppDatabase.Inventory.Instance().watches.Where(item => item.TradingSymbol == netPositionRow.Trading_Symbol).FirstOrDefault();

                    if (netPositionRow.Net_Buy_Qty > netPositionRow.Net_Sell_Qty)
                    {
                        //netPositionRow.Realized_MTM = netSellQty * avgSellPrice - netSellQty * avgBuyPrice;
                        netPositionRow.Unrealized_MTM = double.Parse(string.Format("{0:0.00}", Math.Abs(netPositionRow.Net_Buy_Qty - netPositionRow.Net_Sell_Qty) * watchRow.BidPrice - Math.Abs(netPositionRow.Net_Buy_Qty - netPositionRow.Net_Sell_Qty) * netPositionRow.Buy_Avg_Price));
                    }
                    else if (netPositionRow.Net_Sell_Qty > netPositionRow.Net_Buy_Qty)
                    {
                        //netPositionRow.Realized_MTM = netBuyQty * avgSellPrice - netBuyQty * avgBuyPrice;
                        netPositionRow.Unrealized_MTM = double.Parse(string.Format("{0:0.00}", -Math.Abs(netPositionRow.Net_Buy_Qty - netPositionRow.Net_Sell_Qty) * watchRow.AskPrice + Math.Abs(netPositionRow.Net_Buy_Qty - netPositionRow.Net_Sell_Qty) * netPositionRow.Sell_Avg_Price));
                    }
                    else if (netPositionRow.Net_Buy_Qty == netPositionRow.Net_Sell_Qty)
                    {
                        //netPositionRow.Realized_MTM = netBuyQty * avgSellPrice - netBuyQty * avgBuyPrice;
                        netPositionRow.Unrealized_MTM = 0;
                    }
                    foreach (DataGridViewRow row in dataGridViewNetPosition.Rows)
                    {
                        if (row.Cells[(int)NetPostionColumns.Trading_Symbol].Value.ToString() == netPositionRow.Trading_Symbol)
                        {
                            row.Cells[(int)NetPostionColumns.Unrealized_MTM].Value = netPositionRow.Unrealized_MTM.ToString("0.00");
                            netPositionRow.MTM = netPositionRow.Unrealized_MTM + netPositionRow.Realized_MTM;
                            row.Cells[(int)NetPostionColumns.MTM].Value = (netPositionRow.MTM).ToString("0.00");
                        }
                    }
                }


                labelBQ.Text = "BQ:0";
                labelBV.Text = "BV:0";
                labelSQ.Text = "SQ:0";
                labelSV.Text = "SV:0";
                labelNQ.Text = "NET QTY:0";
                labelNV.Text = "NET VAL:0";
                labelMTM.Text = "MTM:0";
                foreach (var netPositionRow in AppDatabase.Inventory.Instance().NetPosition)
                {

                    labelBQ.Text = "BQ:" + (int.Parse(labelBQ.Text.Split(':')[1]) + netPositionRow.Net_Buy_Qty);
                    labelBV.Text = "BV:" + (double.Parse(labelBV.Text.Split(':')[1]) + netPositionRow.Net_Buy_Value);

                    
                    labelSQ.Text = "SQ:" + (int.Parse(labelSQ.Text.Split(':')[1]) + netPositionRow.Net_Sell_Qty);
                    labelSV.Text = "SV:" + (double.Parse(labelSV.Text.Split(':')[1]) +netPositionRow.Net_Sell_Value);
                    

                    labelNQ.Text = "NET QTY:" + (int.Parse(labelSQ.Text.Split(':')[1]) + int.Parse(labelBQ.Text.Split(':')[1]));
                    labelNV.Text = "NET VAL:" + (double.Parse(labelSV.Text.Split(':')[1]) + double.Parse(labelBV.Text.Split(':')[1]));

                    labelMTM.Text = "MTM:" + (double.Parse(labelMTM.Text.Split(':')[1]) + netPositionRow.MTM);
                }

            }

        }
        

        private void NetPosition_Load(object sender, EventArgs e)
        {
            GenerateColumns();
            foreach (var tradingSYmbol in AppDatabase.Inventory.Instance().ClosedOrders.Select(item => item.Trading_Symbol).Distinct().ToList())
            {
                //var openOrders = AppDatabase.Inventory.Instance().OpenOrders.Select(item => item.Trading_Symbol == tradingSYmbol);
                var closedOrders = AppDatabase.Inventory.Instance().ClosedOrders.Where(item => item.Trading_Symbol == tradingSYmbol);
                NetPositionRow netPositionRow = AppDatabase.Inventory.Instance().NetPosition.Where(item => item.Trading_Symbol == tradingSYmbol).FirstOrDefault();
                WatchRow watchRow = AppDatabase.Inventory.Instance().watches.Where(item => item.TradingSymbol == tradingSYmbol).FirstOrDefault();
                Security security = AppDatabase.Inventory.Instance().securities.Where(item => item.Description == tradingSYmbol).FirstOrDefault();
                int netBuyQty = 0;
                int netSellQty =0;
                double netBuyValue = 0;
                double netSellValue = 0;
                double avgSellPrice = 0;
                double avgBuyPrice = 0;
                foreach(var closedOrder in closedOrders)
                {
                    
                    if(netPositionRow == null)
                    {
                        netPositionRow = new NetPositionRow(closedOrder.User_Id, closedOrder.Account_Id, "", closedOrder.Exch_Segment, "", "", closedOrder.Option_Type, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, closedOrder.Trading_Symbol, "", closedOrder.Expiry_Date, closedOrder.Strike_Price);
                        AppDatabase.Inventory.Instance().NetPosition.Add(netPositionRow);
                    }
                    if(closedOrder.Buy_Sell == "Buy")
                    {
                        netBuyQty += closedOrder.Traded_Qty;
                        netBuyValue += closedOrder.Traded_Qty * closedOrder.Price;
                        if(avgBuyPrice==0)
                        {
                            avgBuyPrice = closedOrder.Price;
                        }
                        else
                        {
                            avgBuyPrice = (avgBuyPrice + closedOrder.Price) / 2;
                        }

                    }
                    else if(closedOrder.Buy_Sell == "Sell")
                    {
                        netSellQty += closedOrder.Traded_Qty;
                        netSellValue += closedOrder.Traded_Qty * closedOrder.Price;
                        if (avgSellPrice == 0)
                        {
                            avgSellPrice = closedOrder.Price;
                        }
                        else
                        {
                            avgSellPrice = (avgSellPrice + closedOrder.Price) / 2;
                        }
                    }
                }
                netPositionRow.Instrument_Name = security.series.ToString();
                netPositionRow.Net_Buy_Qty = netBuyQty;
                netPositionRow.Net_Sell_Qty = netSellQty;
                netPositionRow.Net_Qty = netBuyQty - netSellQty;
                netPositionRow.Net_Buy_Value = -netBuyValue;
                netPositionRow.Net_Sell_Value = netSellValue;
                netPositionRow.Net_Value = -netBuyValue + netSellValue;
                netPositionRow.Buy_Avg_Price = avgBuyPrice;
                netPositionRow.Sell_Avg_Price = avgSellPrice;
                //netPositionRow.Realized_MTM = -netBuyValue + netSellValue;
                
                if(netBuyQty >netSellQty)
                {
                    netPositionRow.Realized_MTM = netSellQty * avgSellPrice - netSellQty * avgBuyPrice;
                    netPositionRow.Unrealized_MTM = Math.Abs(netBuyQty - netSellQty) * watchRow.BidPrice - Math.Abs(netBuyQty - netSellQty) * netPositionRow.Buy_Avg_Price;
                }
                else if(netSellQty>netBuyQty)
                {
                    netPositionRow.Realized_MTM = netBuyQty * avgSellPrice - netBuyQty * avgBuyPrice;
                    netPositionRow.Unrealized_MTM = -Math.Abs(netBuyQty - netBuyQty) * watchRow.AskPrice + Math.Abs(netBuyQty - netSellQty)  * netPositionRow.Sell_Avg_Price;
                }
                else if(netBuyQty == netSellQty)
                {
                    netPositionRow.Realized_MTM = netBuyQty * avgSellPrice - netBuyQty * avgBuyPrice;
                    netPositionRow.Unrealized_MTM = 0;
                }
                netPositionRow.MTM = netPositionRow.Realized_MTM + netPositionRow.Unrealized_MTM;
                dataGridViewNetPosition.Rows.Add(netPositionRow.User_Id,
        netPositionRow.Account_Id,
        netPositionRow.Exch_Segment,
        netPositionRow.Trading_Symbol,
        netPositionRow.Instrument_Name,
        netPositionRow.Option_Type,
        netPositionRow.Net_Buy_Value.ToString("0.00"),
        netPositionRow.Net_Sell_Value,
        netPositionRow.Net_Value.ToString("0.00"),
        netPositionRow.Net_Buy_Qty,
        netPositionRow.Net_Sell_Qty,
        netPositionRow.Net_Qty,
        netPositionRow.BEP,
        netPositionRow.Sell_Avg_Price.ToString("0.00"),
        netPositionRow.Buy_Avg_Price.ToString("0.00"),
        netPositionRow.Last_Traded_Price,
        netPositionRow.MTM.ToString("0.00"),
        netPositionRow.Realized_MTM.ToString("0.00"),
        netPositionRow.Unrealized_MTM.ToString("0.00"),
        netPositionRow.El_MTM,
        netPositionRow.Trading_Symbol,
        netPositionRow.Client_Context,
        netPositionRow.Series_Expity,
        netPositionRow.Strike_Price);
            }
        }

        void GenerateColumns()
        {
            foreach(var headerName in Enum.GetNames(typeof(NetPostionColumns)))
            {
                dataGridViewNetPosition.Columns.Add(headerName.Replace('_', '\0') + "Col", headerName.Replace('_', ' '));
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void buttonSquareOff_Click(object sender, EventArgs e)
        {
            int diff = int.Parse(dataGridViewNetPosition.CurrentRow.Cells[(int)NetPostionColumns.Net_Buy_Qty].Value.ToString()) - int.Parse(dataGridViewNetPosition.CurrentRow.Cells[(int)NetPostionColumns.Net_Sell_Qty].Value.ToString());
            NetPositionRow netPositionRow = AppDatabase.Inventory.Instance().NetPosition.Where(item => item.Trading_Symbol == dataGridViewNetPosition.CurrentRow.Cells[(int)NetPostionColumns.Trading_Symbol].Value.ToString()).FirstOrDefault();
            if (diff!=0)
            {
                if(!checkBoxSquareOffExact.Checked)
                {
                    int qtyToadd = (int)(diff * double.Parse(textBoxQtyPer.Text) / 100);
                    if (diff>0)
                    {
                       
                        netPositionRow.Net_Sell_Qty +=qtyToadd;
                    }
                    else 
                    {
                        netPositionRow.Net_Buy_Qty +=qtyToadd;
                    }
                }
                else
                {
                    if(diff>0)
                    {
                        netPositionRow.Net_Sell_Qty += (int)double.Parse(textBoxQtyPer.Text);
                        if(netPositionRow.Net_Sell_Qty>netPositionRow.Net_Buy_Qty)
                        {
                            netPositionRow.Net_Sell_Qty = netPositionRow.Net_Buy_Qty;
                        }
                    }
                    else
                    {
                        netPositionRow.Net_Buy_Qty += (int)double.Parse(textBoxQtyPer.Text);
                        if(netPositionRow.Net_Buy_Qty>netPositionRow.Net_Sell_Qty)
                        {
                            netPositionRow.Net_Buy_Qty = netPositionRow.Net_Sell_Qty;
                        }
                    }
                }
            }
        }
    }
}
