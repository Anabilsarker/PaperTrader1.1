using AppDatabase;
using Domain.ApiProtocol.Base;
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
    public partial class BuySellUserControl : UserControl
    {
        public bool isBuyWindow = true;
        public WatchRow _watchRow;
        public Security _security;

        public BuySellUserControl()
        {
            InitializeComponent();
            comboBoxSegment.Items.AddRange(new[] { "NSEFO" });
            comboBoxSegment.SelectedIndex = 0;
            comboBoxType.Items.AddRange(new[] { "CE", "PE" });
            comboBoxType.SelectedIndex = 0;
            comboBoxPro.Items.AddRange(new[] { "Cli" });
            comboBoxPro.SelectedIndex = 0;
            comboBoxOrderType.Items.AddRange(new[] { "LIMIT", "MARKET", "SL" });
            comboBoxOrderType.SelectedIndex = 0;
            comboBoxValidity.Items.AddRange(new[] { "DAY", "IOC" });
            comboBoxValidity.SelectedIndex = 0;
            comboBoxProdType.Items.AddRange(new[] { "CNC", "MIS", "NRML" });
            comboBoxProdType.SelectedIndex = 0;
            textBoxDisQty.Text = "0";
            textBoxNoOfDays.Text = "0";
            textBoxMktProt.Text = "0";
            textBoxTrPrice.Text = "0";
            comboBoxValidityDate.Items.Add(DateTime.Today.ToString("dd-MM-yyyy"));
            comboBoxValidityDate.SelectedIndex = 0;
            //comboBoxClientId.Items.Add(AppDatabase.Inventory.Instance().ClientID);
            //comboBoxClientId.SelectedIndex = 0;
        }

        public void SetupBuySellWindow()
        {
            SetStyle();
            SetValues();
        }
        void SetStyle()
        {
            if (isBuyWindow)
            {
                this.labelBuySellOrderWindow.Text = "Buy Order Entry";
                this.panel1.BackColor = Color.FromArgb(128, 128, 200);
            }
            else
            {
                this.labelBuySellOrderWindow.Text = "Sell Order Entry";
                this.panel1.BackColor = Color.FromArgb(255, 102, 106);
            }
        }

        void SetValues()
        {
            if (_watchRow != null)
            {
                _security = AppDatabase.Inventory.Instance().securities.Where(item => item.Description == _watchRow.TradingSymbol).FirstOrDefault();
                comboBoxExpiry.Text = _security.ContractExpiration.ToString();
                comboBoxType.Text = ((OptionType)_security.OptionType).ToString();//error
                comboBoxInstrumentType.Text = _security.instrumentType.ToString();
                comboBoxSymbol.Text = _security.name;
                comboBoxStrike.Text = _security.StrikePrice.ToString();

            if (isBuyWindow)
                {
                    this.textBoxQty.Text = _security.LotSize.ToString();
                    this.textBoxPrice.Text = _watchRow.AskPrice.ToString();
                }
                else
                {
                    this.textBoxQty.Text = _security.LotSize.ToString();
                    this.textBoxPrice.Text = _watchRow.BidPrice.ToString();
                }
            }
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private Point MouseDownLocation;
        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Left = e.X + this.Left - MouseDownLocation.X;
                this.Top = e.Y + this.Top - MouseDownLocation.Y;
            }
        }

        private void comboBoxSegment_SelectedIndexChanged(object sender, EventArgs e)
        {

            //comboBoxSymbol.Items.Clear();
            //var symbols = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), comboBoxSegment.Text)).Select(item => item.name).Distinct().ToList();
            //symbols.Sort();
            //foreach (var el in symbols)
            //{
            //    comboBoxSymbol.Items.Add(el);
            //}
            //if (symbols.Count() > 0)
            //    comboBoxSymbol.SelectedIndex = 0;
        }

        private void comboBoxOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxInstrumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxExpiry.Items.Clear();
            var expiries = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), comboBoxSegment.Text) && item.name == comboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), comboBoxInstrumentType.Text)).Select(item => item.ContractExpiration).Distinct().ToList();
            expiries.Sort();
            foreach (var el in expiries)
            {
                comboBoxExpiry.Items.Add(el);
            }
            if (expiries.Count() > 0)
                comboBoxExpiry.SelectedIndex = 0;
        }

        private void comboBoxSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxInstrumentType.Items.Clear();
            var expiries = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), comboBoxSegment.Text) && item.name == comboBoxSymbol.Text).Select(item => item.series).Distinct().ToList();
            expiries.Sort();
            foreach (var el in expiries)
            {
                comboBoxInstrumentType.Items.Add(el);
            }
            if (expiries.Count() > 0)
                comboBoxInstrumentType.SelectedIndex = 0;
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonSubmit.Focus();
        }

        private void comboBoxStrike_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //if (comboBoxInstrumentType.Text.Contains("OPT"))
                //{
                //    var security = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), toolStripComboBoxSegment.Text) && item.name == toolStripComboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), toolStripComboBoxInstrument.Text) && item.ContractExpiration == DateTime.Parse(toolStripComboBoxExpiry.Text) && item.StrikePrice.ToString() == toolStripComboBoxStrike.Text && toolStripComboBoxOptionType.Text == ((OptionType)item.OptionType).ToString()).ToList().FirstOrDefault();
                //    toolStripLabelScript.Text = security.Description;
                //}
                //else if (comboBoxInstrumentType.Text.Contains("FUT"))
                //{
                //    var security = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), toolStripComboBoxSegment.Text) && item.name == toolStripComboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), toolStripComboBoxInstrument.Text) && item.ContractExpiration == DateTime.Parse(toolStripComboBoxExpiry.Text)).FirstOrDefault();
                //    toolStripLabelScript.Text = security.Description;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant find instrument");
            }
            finally
            {
                buttonSubmit.Focus();
            }
        }

        private void comboBoxExpiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxStrike.Items.Clear();
            var strikes = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), comboBoxSegment.Text) && item.name == comboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), comboBoxInstrumentType.Text) && item.ContractExpiration.ToString("dd-MM-yyyy HH:mm") == comboBoxExpiry.Text).Select(item => item.StrikePrice).Distinct().ToList();
            strikes.Sort();
            foreach (var el in strikes)
            {
                if (el != 0)
                    comboBoxStrike.Items.Add(el);
            }
            if (strikes.Count() > 1)
                comboBoxStrike.SelectedIndex = 0;
            try
            {
                //if (comboBoxInstrumentType.Text.Contains("OPT"))
                //{
                //    var security = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), comboBoxSegment.Text) && item.name == comboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), comboBoxInstrumentType.Text) && item.ContractExpiration == DateTime.Parse(comboBoxExpiry.Text) && item.StrikePrice.ToString() == comboBoxStrike.Text && comboBoxType.Text == ((OptionType)item.OptionType).ToString()).ToList().FirstOrDefault();
                //    toolStripLabelScript.Text = security.Description;
                //}
                //else if (comboBoxInstrumentType.Text.Contains("FUT"))
                //{
                //    var security = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), comboBoxSegment.Text) && item.name == comboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), comboBoxInstrumentType.Text) && item.ContractExpiration == DateTime.Parse(comboBoxExpiry.Text)).FirstOrDefault();
                //    toolStripLabelScript.Text = security.Description;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant find instrument");
            }
            finally
            {
                buttonSubmit.Focus();
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            OrderRow order = new OrderRow();
            order.Account_Id = comboBoxClientId.Text;
            order.User_Id = comboBoxClientId.Text;
            order.Exch_Segment = comboBoxSegment.Text;
            order.Product_type = comboBoxProdType.Text;
            order.Buy_Sell = this.labelBuySellOrderWindow.Text.Split(' ')[0];
            if (comboBoxStrike.Text!= "00" )
            {
                order.Trading_Symbol = comboBoxSymbol.Text + DateTime.Parse(comboBoxExpiry.Text).ToString("yyMMM").ToUpper() + "FUT";
            }
            else
            {
                order.Trading_Symbol = comboBoxSymbol.Text + DateTime.Parse(comboBoxExpiry.Text).ToString("yyMMM").ToUpper() + comboBoxStrike.Text + comboBoxType.Text; //M & MFIN21OCTFUT
            }
            order.Option_Type = comboBoxOrderType.Text;
            int.TryParse(textBoxQty.Text, out order.Total_Qty); //Need Fix
            int.TryParse(textBoxQty.Text, out order.Pending_Qty);
            double.TryParse(textBoxPrice.Text, out order.Price);
            double.TryParse(textBoxTrPrice.Text, out order.Trigger_Price);
            order.BWL = comboBoxBasket.Text;
            order.Order_Type = comboBoxOrderType.Text;
            order.Average_Price += order.Price;
            double.TryParse(comboBoxStrike.Text, out order.Strike_Price);
            DateTime.TryParse(comboBoxExpiry.Text, out order.Expiry_Date);
            order.Status = "Open";
            order.Order_Id = AppDatabase.Inventory.Instance().OpenOrders.Count + 1;
            AppDatabase.Inventory.Instance().OpenOrders.Add(order);
            if (AppDatabase.Inventory.Instance().NetPosition.Where(item => item.Trading_Symbol == order.Trading_Symbol).FirstOrDefault() != null)
            {
                AppDatabase.Inventory.Instance().NetPosition.Add(new NetPositionRow(order.User_Id, order.Account_Id, "", order.Exch_Segment, comboBoxSymbol.Text, comboBoxInstrumentType.Text, order.Order_Type, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, order.Trading_Symbol, "", order.Expiry_Date, order.Strike_Price));
            }
            this.Visible = false;
        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
