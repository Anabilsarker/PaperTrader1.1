using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiAccess
{
    
    public class ConnectionToApi
    {
        ConnectionToApi() { }
        private static readonly object lock1 = new object ();
        private static ConnectionToApi _instance;
        public XTS xts;
        public static ConnectionToApi Instance
        {
            get
            {
                lock (lock1)
                {
                    if (_instance == null)
                        _instance = new ConnectionToApi();
                }
                return _instance;
            }

        }
        public async Task ConfigureApi()
        {
            //xts = new XTS();
            //XTS.InitializeClient();
            //await xts.Login();
            //await xts.ClientConfig();
            //await xts.Master();
            //await xts.Subscribe(2, 48740);
            //xts.CreateMarketdataSocket();
        }
    }
}
