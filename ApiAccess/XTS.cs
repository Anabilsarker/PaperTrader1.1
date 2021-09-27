using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using System.Configuration;
using Domain.ApiProtocol.Response.ApiResponse;
using AppDatabase;
using Domain.ApiProtocol.Response.LiveDataResponse;

namespace ApiAccess
{
    public delegate void delMarketDataUpdate(object obj);
    public class XTS
    {
        public static HttpClient apiClient { get; set; } = new HttpClient();
        string _token;
        string _userID;
        string _appVersion;
        LoginResponse loginResponse = new LoginResponse();
        ConfigResponse configResponse = new ConfigResponse();
        public event delMarketDataUpdate GridUpdate;
        public event delMarketDataUpdate InvetoryUpdate;

        public static void InitializeClient()
        {
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("https://xts.compositedge.com/marketdata");
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task Login()
        {
            string secrateKey = System.Configuration.ConfigurationManager.AppSettings["secrateKey"];
            string apiKey = System.Configuration.ConfigurationManager.AppSettings["apiKey"];
            var values = new Dictionary<string, string>
            {

                { "secretKey",secrateKey },
                { "appKey", apiKey },
                { "source", "WebAPI" }

            };
            var content = new FormUrlEncodedContent(values);
            string loginUri = apiClient.BaseAddress.ToString() + "/auth/login";
            using (HttpResponseMessage responseMessage = await XTS.apiClient.PostAsync(loginUri, content))
            {
                loginResponse = await responseMessage.Content.ReadAsAsync<LoginResponse>();
                AppDatabase.Inventory.Instance().ClientID = loginResponse.result.userID;
            }
        }

        public async Task ClientConfig()
        {
            var values = new Dictionary<string, string>
            {

                { "userID", "" },
                { "source", "WebAPI" }

            };
            var content = new FormUrlEncodedContent(values);
            string clientConfigUri = apiClient.BaseAddress.AbsoluteUri + "/config/clientConfig";
            Console.WriteLine(loginResponse.result.token.ToString());
            apiClient.DefaultRequestHeaders.Authorization
            = new AuthenticationHeaderValue(loginResponse.result.token.ToString());
            using (HttpResponseMessage responseMessage = await XTS.apiClient.GetAsync(clientConfigUri))
            {
                Console.WriteLine(responseMessage.Content.ReadAsStringAsync().Result.ToString());
                configResponse = await responseMessage.Content.ReadAsAsync<ConfigResponse>();


            }
        }

        public async Task Master()
        {
            var values = new Dictionary<string, string>
            {
                {
                    "exchangeSegmentList", "[\"NSECM\",\"NSECD\",\"NSEFO\"]"
                }
            };
            var content = new FormUrlEncodedContent(values);
            string masterDataUri = apiClient.BaseAddress.AbsoluteUri + "/instruments/master";
            using (HttpResponseMessage responseMessage = await XTS.apiClient.PostAsync(masterDataUri, content))
            {
                MasterResponse masterResponse = await responseMessage.Content.ReadAsAsync<MasterResponse>();
                Inventory.Instance().contractFile.ParseAndWriteMasterData(masterResponse.result);
                //ContractFile contract = new ContractFile(masterResponse.result);
            }
        }

        public async Task Subscribe(int segment, int instrumentId)
        {
            string values = string.Format("{{\"instruments\": [{{\"exchangeSegment\": {0},\"exchangeInstrumentID\": {1}}}],\"xtsMessageCode\": 1502}}", segment, instrumentId);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            string subscriptionUri = apiClient.BaseAddress.AbsoluteUri + "/instruments/subscription";
            apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(loginResponse.result.token.ToString());
            using (HttpResponseMessage responseMessage = await XTS.apiClient.PostAsync(subscriptionUri, content))
            {
                SubscriptionResponse masterResponse = await responseMessage.Content.ReadAsAsync<SubscriptionResponse>();
            }

        }
        public async Task UnSubscribe(int segment, int instrumentId)
        {
            string values = string.Format("{{\"instruments\": [{{\"exchangeSegment\": {0},\"exchangeInstrumentID\": {1}}}],\"xtsMessageCode\": 1502}}", segment, instrumentId);
            var content = new StringContent(values, Encoding.UTF8, "application/json");
            string unsubscriptionUri = apiClient.BaseAddress.AbsoluteUri + "/instruments/subscription";
            Console.WriteLine("Content: {0}", values.ToString());
            using (HttpResponseMessage responseMessage = await XTS.apiClient.PutAsync(unsubscriptionUri, content))
            {
                string str = responseMessage.Content.ReadAsStringAsync().Result;
                Console.WriteLine(str);
                SubscriptionResponse masterResponse = await responseMessage.Content.ReadAsAsync<SubscriptionResponse>();
                Console.WriteLine(masterResponse.description);
                //loginResponse = await responseMessage.Content.ReadAsAsync<LoginResponse>();
            }
        }

        public void CreateMarketdataSocket()
        {
            //Connect to the socket
            Quobject.SocketIoClientDotNet.Client.IO.Options options = new Quobject.SocketIoClientDotNet.Client.IO.Options()
            {
                IgnoreServerCertificateValidation = true,
                Path = "/marketdata/socket.io",
                Query = new Dictionary<string, string>()
                {
                    { "token", loginResponse.result.token },
                    { "userID", loginResponse.result.userID },
                    { "source", "WebAPI" },
                    { "publishFormat", "JSON" },
                    { "broadcastMode", "Full" }
                }
            };

            var socket = IO.Socket("https://xts.compositedge.com", options);

            //subscribe to the base methods
            socket.On(Socket.EVENT_CONNECT, (data) =>
            {
                Console.WriteLine($"Connect {data}");
                //this.OnConnectionState(ConnectionEvents.connect, data);
            });

            socket.On("joined", (data) =>
            {
                //this.isConnectedToSocket = true;
                //this.OnConnectionState(ConnectionEvents.joined, data);
            });

            socket.On("success", (data) =>
            {
                Console.WriteLine("Success");
                //this.OnConnectionState(ConnectionEvents.success, data);
            });

            socket.On("warning", (data) =>
            {
                //OnConnectionState(ConnectionEvents.warning, data);
            });

            socket.On("error", (data) =>
            {
                Console.WriteLine($"Error {data.ToString()}");
                //OnConnectionState(ConnectionEvents.error, data);
            });

            socket.On("logout", (data) =>
            {
                //this.isConnectedToSocket = false;
                //OnConnectionState(ConnectionEvents.logout, data);
            });

            socket.On("disconnect", (data) =>
            {
                //OnConnectionState(ConnectionEvents.logout, data);
            });

            socket.On($"1501-JSON-Full", (data) =>
            {

            });

            socket.On($"1502-json-full", (data) =>
            {
                Console.WriteLine(data.ToString());
                if (GridUpdate != null)
                {
                    GridUpdate(data);
                }
                if (InvetoryUpdate != null)
                {
                    InvetoryUpdate(data);
                }
                //OnData<MarketDepth>(MarketDataPorts.marketDepthEvent, data, publishFormat, broadcastMode);
            });
        }
    }
}
