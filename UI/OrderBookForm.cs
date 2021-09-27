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
    public partial class OrderBookForm : Form
    {
        Orders openOrdersForm;
        Orders closedOrdersForm;
        public OrderBookForm()
        {
            InitializeComponent();
            this.IsMdiContainer = true;

            openOrdersForm = new Orders("Open Orders");
            openOrdersForm.MdiParent = this;
            openOrdersForm.Dock = DockStyle.Fill;
            splitContainer1.Panel1.Controls.Add(openOrdersForm);

            closedOrdersForm = new Orders("Closed Orders");
            closedOrdersForm.MdiParent = this;
            closedOrdersForm.Dock = DockStyle.Fill;
            splitContainer1.Panel2.Controls.Add(closedOrdersForm);
            openOrdersForm.Show();
            closedOrdersForm.Show();
            AppDatabase.Inventory.Instance().QTyAndValueUpdateEvent += UpdateQtyAndValue;
            UpdateQtyAndValue();
            //panelMain.Controls.Add(new Orders());
        }

        private void labelNV_Click(object sender, EventArgs e)
        {

        }

        private void OrderBookForm_Load(object sender, EventArgs e)
        {

        }

        public void UpdateQtyAndValue()
        {
            if (labelBQ.InvokeRequired)
            {
                Action safeWrite = delegate { UpdateQtyAndValue(); };
                labelBQ.Invoke(safeWrite);

            }
            else
            {
                labelBQ.Text = "BQ:0";
                labelBV.Text = "BV:0";
                labelSQ.Text = "SQ:0";
                labelSV.Text = "SV:0";
                labelNQ.Text = "NQ:0";
                labelNV.Text = "NV:0";
                    foreach (var order in AppDatabase.Inventory.Instance().OpenOrders)
                    {
                        if (order.Buy_Sell == "Buy")
                        {
                            labelBQ.Text = "BQ:"+(int.Parse(labelBQ.Text.Split(':')[1]) + order.Pending_Qty).ToString();
                            labelBV.Text = "BV:"+(double.Parse(labelBV.Text.Split(':')[1]) + order.Pending_Qty*order.Price).ToString();
                            
                        }
                        else if (order.Buy_Sell == "Sell")
                        {
                            labelSQ.Text = "SQ:"+(int.Parse(labelSQ.Text.Split(':')[1]) + order.Pending_Qty).ToString();
                            labelSV.Text = "SV:"+(double.Parse(labelSV.Text.Split(':')[1]) + order.Pending_Qty * order.Price).ToString();
                        }

                        labelNQ.Text = "NQ:"+(int.Parse(labelSQ.Text.Split(':')[1]) + int.Parse(labelBQ.Text.Split(':')[1])).ToString();
                        labelNV.Text = "NV:"+(double.Parse(labelSV.Text.Split(':')[1]) + double.Parse(labelBV.Text.Split(':')[1])).ToString();
                    }
                    foreach (var order in AppDatabase.Inventory.Instance().ClosedOrders)
                    {

                        
                    }

                
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            openOrdersForm.dataGridViewOrders.CurrentRow.Cells[(int)OrdersColumns.Status].Value = "Cancelled";
            AppDatabase.Inventory.Instance().OpenOrders.RemoveAll(item => item.Order_Id == int.Parse(openOrdersForm.dataGridViewOrders.CurrentRow.Cells[(int)OrdersColumns.Order_Id].Value.ToString()));
            openOrdersForm.dataGridViewOrders.Rows.Remove(openOrdersForm.dataGridViewOrders.CurrentRow);
        }

        private void buttonCancelAll_Click(object sender, EventArgs e)
        {
            AppDatabase.Inventory.Instance().OpenOrders.Clear();
            openOrdersForm.dataGridViewOrders.Rows.Clear();
        }
    }
}
