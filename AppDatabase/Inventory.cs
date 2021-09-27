using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AppDatabase
{
    public delegate void delUpdate();
    public class Inventory
    {
        /// <summary>
        /// Singolton pattern
        /// </summary>
        private Inventory() 
        { 
        }
        private static Inventory _instance = null;
        public event delUpdate GridUpdateEvent;
        public event delUpdate PositionUpdateEvent ;
        public event delUpdate QTyAndValueUpdateEvent;
        public event delUpdate UpdateNetPositionEvent;


        public void UpdatePosition()
        {

            lock (OpenOrders)
            {
                bool isUpdated = false;
                
                foreach (var openOrder in OpenOrders)
                {
                    WatchRow watchRow = watches.Where(item => item.TradingSymbol == openOrder.Trading_Symbol).FirstOrDefault();
                    
                    
                    if (openOrder.Buy_Sell == "Buy")
                    {
                        if (watchRow.AskPrice <= openOrder.Price)
                        {
                            if (watchRow.AskQty < openOrder.Pending_Qty)
                            {
                                openOrder.Traded_Qty = watchRow.AskQty;
                                openOrder.Pending_Qty = openOrder.Pending_Qty - openOrder.Traded_Qty;
                                openOrder.Status = "Complete";
                                if (openOrder.Average_Price == 0)
                                {
                                    openOrder.Average_Price = watchRow.AskPrice;
                                }
                                else
                                {
                                    openOrder.Average_Price = (openOrder.Average_Price + watchRow.AskPrice) / 2;
                                }
                                isUpdated = true;
                                
                                lock (ClosedOrders)
                                {
                                    ClosedOrders.Add(openOrder);
                                }

                            }
                            else if(openOrder.Pending_Qty!=0)
                            {
                                openOrder.Traded_Qty = openOrder.Pending_Qty;
                                openOrder.Pending_Qty = 0;
                                openOrder.Status = "Complete";
                                if (openOrder.Average_Price == 0)
                                {
                                    openOrder.Average_Price = watchRow.AskPrice;
                                }
                                else
                                {
                                    openOrder.Average_Price = (openOrder.Average_Price + watchRow.AskPrice) / 2;
                                }
                                isUpdated = true;
                                lock (ClosedOrders)
                                {
                                    ClosedOrders.Add(openOrder);
                                }
                            }
                            

                        }
                    }
                    else if (openOrder.Buy_Sell == "Sell")
                    {
                        if (watchRow.BidPrice <= openOrder.Price)
                        {
                            if (watchRow.AskQty < openOrder.Pending_Qty)
                            {
                                openOrder.Traded_Qty = watchRow.BidQty;
                                openOrder.Pending_Qty = openOrder.Pending_Qty - openOrder.Traded_Qty;
                                openOrder.Status = "Complete";
                                if (openOrder.Average_Price == 0)
                                {
                                    openOrder.Average_Price = watchRow.BidPrice;
                                }
                                else
                                {
                                    openOrder.Average_Price = (openOrder.Average_Price + watchRow.BidPrice) / 2;
                                }
                                isUpdated = true;

                                lock (ClosedOrders)
                                {
                                    ClosedOrders.Add(openOrder);
                                }

                            }
                            else if (openOrder.Pending_Qty != 0)
                            {
                                openOrder.Traded_Qty = openOrder.Pending_Qty;
                                openOrder.Pending_Qty = 0;
                                openOrder.Status = "Complete";
                                if (openOrder.Average_Price == 0)
                                {
                                    openOrder.Average_Price = watchRow.BidPrice;
                                }
                                else
                                {
                                    openOrder.Average_Price = (openOrder.Average_Price + watchRow.BidPrice) / 2;
                                }
                                isUpdated = true;
                                lock (ClosedOrders)
                                {
                                    ClosedOrders.Add(openOrder);
                                }
                            }


                        }
                    }
                }
                if (UpdateNetPositionEvent != null)
                {
                    UpdateNetPositionEvent();
                }
                
                OpenOrders.RemoveAll(el => el.Pending_Qty == 0);
                if (PositionUpdateEvent != null && isUpdated)
                {
                    PositionUpdateEvent();
                  
                }
                if(QTyAndValueUpdateEvent!=null && isUpdated)
                {
                    QTyAndValueUpdateEvent();
                }
            }
        }

        

        public static Inventory Instance()
        {
            if(_instance==null)
            {
                _instance = new Inventory();
            }
            return _instance;
        }
        public string ClientID = "";
        public string ClientName = "";
        /// <summary>
        /// MasterDataFile
        /// MasterDataDictionary
        /// </summary>
        public ContractFile contractFile = new ContractFile();
        public List<Security> securities = new List<Security>();

        /// <summary>
        /// Display Data
        /// </summary>
        
        public List<WatchRow> watches = new List<WatchRow>();

        /// <summary>
        /// Order details
        /// </summary>
        public List<OrderRow> OpenOrders = new List<OrderRow>();
        public List<OrderRow> ClosedOrders = new List<OrderRow>();
        public List<NetPositionRow> NetPosition = new List<NetPositionRow>();
       
    }
}
