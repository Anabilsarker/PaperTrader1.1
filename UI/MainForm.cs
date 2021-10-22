using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using Services.Domain;
using AppDatabase;
using Domain.ApiProtocol.Base;
using Domain.Models;
using Views;
using Newtonsoft.Json;
using Domain.ApiProtocol.Response.LiveDataResponse;
using System.Threading;
using ApiAccess;

namespace UI
{
    public partial class MainForm : Form, IMainFormView
    {
        WatchRow watchRow = new WatchRow();
        double high = 0, low = 0, bidqty = 0, bidprice = 0, askqty = 0, askprice = 0;
        LoadingForm _loadingForm;
        WatchRowServices watchRowServices;
        SecurityServices securityServices;
        public MainForm(LoadingForm loadingForm)
        {
            _loadingForm = loadingForm;
            InitializeComponent();
            loadingForm.Visible = false;
            watchRowServices = new WatchRowServices(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ApiAccess.ConnectionToApi.Instance.xts.GridUpdate += UpdateGrid;
            toolStripComboBoxOptionType.Items.AddRange(new[] { "CE", "PE" });
            toolStripComboBoxOptionType.SelectedIndex = 0;
            toolStripComboBoxStrike.Visible = false;
            toolStripComboBoxOptionType.Visible = false;


            var segments = Inventory.Instance().securities.Select(item => item.exchangeSegment).Distinct().ToList();
            segments.Sort();
            foreach (var el in segments)
            {
                toolStripComboBoxSegment.Items.Add(el);
            }
            if (segments.Count() > 0)
                toolStripComboBoxSegment.SelectedIndex = 0;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _loadingForm.Close();
        }

        private void toolStripComboBoxSegment_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripComboBoxSymbol.Items.Clear();
            var symbols = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), toolStripComboBoxSegment.Text)).Select(item => item.name).Distinct().ToList();
            symbols.Sort();
            foreach (var el in symbols)
            {
                toolStripComboBoxSymbol.Items.Add(el);
            }
            if (symbols.Count() > 0)
                toolStripComboBoxSymbol.SelectedIndex = 0;
        }

        private void toolStripComboBoxSymbol_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripComboBoxInstrument.Items.Clear();
            var expiries = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), toolStripComboBoxSegment.Text) && item.name == toolStripComboBoxSymbol.Text).Select(item => item.series).Distinct().ToList();
            expiries.Sort();
            foreach (var el in expiries)
            {
                toolStripComboBoxInstrument.Items.Add(el);
            }
            if (expiries.Count() > 0)
                toolStripComboBoxInstrument.SelectedIndex = 0;
        }

        private void toolStripComboBoxInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBoxInstrument.Text.Contains("OPT"))
            {
                toolStripComboBoxStrike.Visible = true;
                toolStripComboBoxOptionType.Visible = true;
            }
            else if (toolStripComboBoxInstrument.Text.Contains("FUT"))
            {
                toolStripComboBoxStrike.Visible = false;
                toolStripComboBoxOptionType.Visible = false;
            }
            toolStripComboBoxExpiry.Items.Clear();
            var expiries = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), toolStripComboBoxSegment.Text) && item.name == toolStripComboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), toolStripComboBoxInstrument.Text)).Select(item => item.ContractExpiration).Distinct().ToList();
            expiries.Sort();
            foreach (var el in expiries)
            {
                toolStripComboBoxExpiry.Items.Add(el);
            }
            if (expiries.Count() > 0)
                toolStripComboBoxExpiry.SelectedIndex = 0;
        }

        private void toolStripComboBoxExpiry_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripComboBoxStrike.Items.Clear();
            var strikes = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), toolStripComboBoxSegment.Text) && item.name == toolStripComboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), toolStripComboBoxInstrument.Text) && item.ContractExpiration == DateTime.Parse(toolStripComboBoxExpiry.Text)).Select(item => item.StrikePrice).Distinct().ToList();
            strikes.Sort();
            foreach (var el in strikes)
            {
                if (el != 0)
                    toolStripComboBoxStrike.Items.Add(el);
            }
            if (strikes.Count() > 1)
                toolStripComboBoxStrike.SelectedIndex = 0;
            try
            {
                if (toolStripComboBoxInstrument.Text.Contains("OPT"))
                {
                    var security = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), toolStripComboBoxSegment.Text) && item.name == toolStripComboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), toolStripComboBoxInstrument.Text) && item.ContractExpiration == DateTime.Parse(toolStripComboBoxExpiry.Text) && item.StrikePrice.ToString() == toolStripComboBoxStrike.Text && toolStripComboBoxOptionType.Text == ((OptionType)item.OptionType).ToString()).ToList().FirstOrDefault();
                    toolStripLabelScript.Text = security.Description;
                }
                else if (toolStripComboBoxInstrument.Text.Contains("FUT"))
                {
                    var security = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), toolStripComboBoxSegment.Text) && item.name == toolStripComboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), toolStripComboBoxInstrument.Text) && item.ContractExpiration == DateTime.Parse(toolStripComboBoxExpiry.Text)).FirstOrDefault();
                    toolStripLabelScript.Text = security.Description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant find instrument");
            }
            finally
            {
                dataGridViewWatch.Focus();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewWatch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var security = Inventory.Instance().securities.Where(item => item.Description == toolStripLabelScript.Text).FirstOrDefault();
                WatchRow watchRow = new WatchRow();
                watchRow.exchangeSegment = security.exchangeSegment;
                watchRow.instrumentId = security.exchangeInstrumentID;
                watchRow.TradingSymbol = security.Description;
                watchRowServices.Add(watchRow);
                dataGridViewWatch.Rows.Add(new[] { watchRow.instrumentId.ToString(),watchRow.TradingSymbol.ToString(), "", "", "", "", "", "", "", "", "", "", "", "" });
            }
            catch
            {
                MessageBox.Show("Cant find instrument");
            }
        }*/

        double oldValue;
        private void UpdateGrid(object data)
        {
            try
            {
                _1502PktStructure _1502pkt = new _1502PktStructure();
                _1502pkt = JsonConvert.DeserializeObject<_1502PktStructure>(data.ToString());
                foreach (DataGridViewRow row in dataGridViewWatch.Rows)
                {

                    watchRow = AppDatabase.Inventory.Instance().watches.Where(item => item.TradingSymbol == row.Cells[(int)WatchRowColumns.TradingSymbol].Value.ToString()).FirstOrDefault();
                    if (int.Parse(row.Cells[(int)WatchRowColumns.ExchangeInstrumentId].Value.ToString()) == _1502pkt.ExchangeInstrumentID)
                    {
                        try
                        {

                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.BidQty].Value.ToString());
                            watchRow.BidQty = _1502pkt.Touchline.BidInfo.Size;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.BidQty].Value = _1502pkt.Touchline.BidInfo.Size;
                        //bidqty = _1502pkt.Touchline.BidInfo.Size;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.BidPrice].Value.ToString());
                            watchRow.BidPrice = _1502pkt.Touchline.BidInfo.Price;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.BidPrice].Value = _1502pkt.Touchline.BidInfo.Price;
                        //bidprice = _1502pkt.Touchline.BidInfo.Price;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.AskPrice].Value.ToString());
                            watchRow.AskPrice = _1502pkt.Touchline.AskInfo.Price;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.AskPrice].Value = _1502pkt.Touchline.AskInfo.Price;
                        //askprice = _1502pkt.Touchline.AskInfo.Price;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.AskQty].Value.ToString());
                            watchRow.AskQty = _1502pkt.Touchline.AskInfo.Size;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.AskQty].Value = _1502pkt.Touchline.AskInfo.Size;
                        //askqty = _1502pkt.Touchline.AskInfo.Size;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.LTP].Value.ToString());
                            watchRow.LTP = _1502pkt.Touchline.LastTradedPrice;
                        }
                        catch
                        {

                        }

                        row.Cells[((int)WatchRowColumns.LTP)].Value = _1502pkt.Touchline.LastTradedPrice;
                        //Data1.LTP = _1502pkt.Touchline.LastTradedPrice;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.PercentChange].Value.ToString());
                            watchRow.PercentChange = _1502pkt.Touchline.PercentChange;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.PercentChange].Value = _1502pkt.Touchline.PercentChange;
                        //Data1.PercentChange = _1502pkt.Touchline.PercentChange;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.ATP].Value.ToString());
                            watchRow.ATP = _1502pkt.Touchline.AverageTradedPrice;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.ATP].Value = _1502pkt.Touchline.AverageTradedPrice;
                        //Data1.ATP = _1502pkt.Touchline.AverageTradedPrice;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.Volume].Value.ToString());
                            watchRow.Volume = _1502pkt.Touchline.TotalTradedQuantity;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.Volume].Value = _1502pkt.Touchline.TotalTradedQuantity;
                        //Data1.Volume = _1502pkt.Touchline.TotalTradedQuantity;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.Open].Value.ToString());
                            watchRow.Open = _1502pkt.Touchline.Open;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.Open].Value = _1502pkt.Touchline.Open;
                        //Data1.Open = _1502pkt.Touchline.Open;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.High].Value.ToString());
                            watchRow.High = _1502pkt.Touchline.High;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.High].Value = _1502pkt.Touchline.High;
                        //high = _1502pkt.Touchline.High;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.Low].Value.ToString());
                            watchRow.Low = _1502pkt.Touchline.Low;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.Low].Value = _1502pkt.Touchline.Low;
                        //low = _1502pkt.Touchline.Low;
                        try
                        {
                            oldValue = double.Parse(row.Cells[(int)WatchRowColumns.PreClose].Value.ToString());
                            watchRow.PreClose = _1502pkt.Touchline.Close;
                        }
                        catch
                        {

                        }

                        row.Cells[(int)WatchRowColumns.PreClose].Value = _1502pkt.Touchline.Close;
                        //Data1.PreClose = _1502pkt.Touchline.Close;


                        if (double.Parse(row.Cells[(int)WatchRowColumns.LTP].Value.ToString()) <= double.Parse(row.Cells[(int)WatchRowColumns.Low].Value.ToString()))
                        {
                            row.DefaultCellStyle.BackColor = Color.SandyBrown;
                        }
                        else if (double.Parse(row.Cells[(int)WatchRowColumns.LTP].Value.ToString()) >= double.Parse(row.Cells[(int)WatchRowColumns.High].Value.ToString()))
                        {
                            row.DefaultCellStyle.BackColor = Color.GreenYellow;
                        }
                        else
                        {

                            row.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                        }
                        Thread trd = new Thread(AppDatabase.Inventory.Instance().UpdatePosition);
                        trd.Start();
                        trd.Join();
                        trd.Abort();
                    }
                }
            }
            catch { }

        }

        private void dataGridViewWatch_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex < 6)
                {
                    if (oldValue > double.Parse(dataGridViewWatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        dataGridViewWatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = (Color)Enum.Parse(typeof(Color), ConfigurationManager.AppSettings["DownColor"]);
                    }
                    else if (oldValue < double.Parse(dataGridViewWatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        dataGridViewWatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = (Color)Enum.Parse(typeof(Color), ConfigurationManager.AppSettings["UpColor"]);
                    }
                    else
                    {
                        dataGridViewWatch.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
                    }
                }
            }
            catch
            {

            }

        }


        private void toolStripComboBoxStrike_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (toolStripComboBoxInstrument.Text.Contains("OPT"))
                {
                    var security = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), toolStripComboBoxSegment.Text) && item.name == toolStripComboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), toolStripComboBoxInstrument.Text) && item.ContractExpiration == DateTime.Parse(toolStripComboBoxExpiry.Text) && item.StrikePrice.ToString() == toolStripComboBoxStrike.Text && toolStripComboBoxOptionType.Text == ((OptionType)item.OptionType).ToString()).ToList().FirstOrDefault();
                    toolStripLabelScript.Text = security.Description;
                }
                else if (toolStripComboBoxInstrument.Text.Contains("FUT"))
                {
                    var security = Inventory.Instance().securities.Where(item => item.exchangeSegment == (ExchangeSegment)Enum.Parse(typeof(ExchangeSegment), toolStripComboBoxSegment.Text) && item.name == toolStripComboBoxSymbol.Text && item.series == (Series)Enum.Parse(typeof(Series), toolStripComboBoxInstrument.Text) && item.ContractExpiration == DateTime.Parse(toolStripComboBoxExpiry.Text)).FirstOrDefault();
                    toolStripLabelScript.Text = security.Description;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cant find instrument");
            }
            finally
            {
                dataGridViewWatch.Focus();
            }
        }

        private void dataGridViewWatch_KeyDown(object sender, KeyEventArgs e)
        {
            buySellUserControl1._watchRow = AppDatabase.Inventory.Instance().watches.Where(item => item.TradingSymbol == dataGridViewWatch.CurrentRow.Cells[(int)WatchRowColumns.TradingSymbol].Value.ToString()).FirstOrDefault();
            if (e.KeyCode == Keys.F1)
            {
                buySellUserControl1.isBuyWindow = true;
                buySellUserControl1.SetupBuySellWindow();
                buySellUserControl1.Visible = true;
            }
            else if (e.KeyCode == Keys.F2)
            {
                buySellUserControl1.isBuyWindow = false;
                buySellUserControl1.SetupBuySellWindow();
                buySellUserControl1.Visible = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    var security = Inventory.Instance().securities.Where(item => item.Description == toolStripLabelScript.Text).FirstOrDefault();
                    
                    watchRow.exchangeSegment = security.exchangeSegment;
                    watchRow.instrumentId = security.exchangeInstrumentID;
                    watchRow.TradingSymbol = security.Description;
                    watchRowServices.Add(watchRow);
                    dataGridViewWatch.Rows.Add(new[] { watchRow.instrumentId.ToString(), watchRow.TradingSymbol.ToString(), "", "", "", "", "", "", "", "", "", "", "", "" });
                }
                catch
                {
                    MessageBox.Show("Cant find instrument");
                }
            }
            else if (e.KeyCode == Keys.F3)
            {
                new OrderBookForm().ShowDialog();
            }
            else if (e.KeyCode == Keys.F11)
            {
                new NetPosition().ShowDialog();
            }
        }


        private void toolStripComboBoxOptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewWatch.Focus();
        }

        private void netPositionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NetPosition().ShowDialog();
        }

        private void orderBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new OrderBookForm().ShowDialog();
        }

        private void userSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult backColor = new Settings().ShowDialog();
        }

        private void refreshBroadcastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApiAccess.ConnectionToApi.Instance.xts.GridUpdate += UpdateGrid;
        }

        private void dataGridViewWatch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            /*if (e.ColumnIndex == 3)
            {
                if (bidprice < low)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
                e.CellStyle.BackColor = Color.Red;
            }
            else if(e.ColumnIndex == 3)
            {
                if(bidprice > high)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
            }
            else if (watchRow.BidPrice == watchRow.Low && e.ColumnIndex == 3)
            {
                //e.CellStyle.BackColor = Color.WhiteSmoke;
            }

            if (e.ColumnIndex == 4)
            {
                if(askprice < low)
                {
                    e.CellStyle.BackColor = Color.Red;
                }
            }
            else if (e.ColumnIndex == 4)
            {
                if(askprice > high)
                {
                    e.CellStyle.BackColor = Color.Green;
                }
            }
            else if (watchRow.AskPrice == watchRow.Low && e.ColumnIndex == 4)
            {
                //e.CellStyle.BackColor = Color.WhiteSmoke;
            }*/
        }
    }
}
