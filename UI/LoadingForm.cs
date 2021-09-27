using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiAccess;
using AppDatabase;
using Views;
using Services.Domain;

namespace UI
{
    public partial class LoadingForm : Form,ILoadingView
    {
        SecurityServices securityServices;
        WatchRowServices watchRowServices;
        
        public LoadingForm()
        {
            InitializeComponent();
        }

        public int LoadingPercent {
            get
            {
                return progressBar.Value;
            }
            set
            {
                progressBar.Value = value;
            }
         }
        public string LoadingText {
            get
            {
                return labelLoading.Text;
            }
            set
            {
                labelLoading.Text = value;
            }
        }
        private async Task ApiInitiate()
        {
            ConnectionToApi.Instance.xts = new XTS();
            XTS.InitializeClient();
            await ConnectionToApi.Instance.xts.Login();
            LoadingText = "Api Login successful.";
            LoadingPercent = 9;
            //await ConnectionToApi.Instance.xts.ClientConfig();
            await ConnectionToApi.Instance.xts.Master();
            LoadingText = "Master data download complete.";
            LoadingPercent = 90;
            ConnectionToApi.Instance.xts.CreateMarketdataSocket();
            LoadingText = "Resistration to Live data complete.";
            LoadingPercent = 100;
            new MainForm(this).ShowDialog();
        }
        private void LoadingForm_Load(object sender, EventArgs e)
        {
            Services.Common.General general = new Services.Common.General();
            ApiInitiate();
        }

        private void LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            
        }
    }
}
