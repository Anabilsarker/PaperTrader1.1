using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
           
        {
            foreach (var color in Enum.GetValues(typeof(System.Drawing.KnownColor)).Cast<System.Drawing.KnownColor>().ToList())
            {
                comboBoxBackgroundColor.Items.Add(color);
                comboBoxDownColor.Items.Add(color);
                comboBoxUpColor.Items.Add(color);
            }

           
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if(comboBoxBackgroundColor.Text!="")
                ConfigurationManager.AppSettings["BackgroundColor"] = comboBoxBackgroundColor.Text;
            if(comboBoxBackgroundColor.Text!="")
                ConfigurationManager.AppSettings["UpColor"] = comboBoxBackgroundColor.Text;
            if(comboBoxBackgroundColor.Text!="")
                ConfigurationManager.AppSettings["DownColor"] = comboBoxBackgroundColor.Text;
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxBackgroundColor.Text != "")
                ConfigurationManager.AppSettings["BackgroundColor"] = comboBoxBackgroundColor.Text;
            if (comboBoxBackgroundColor.Text != "")
                ConfigurationManager.AppSettings["UpColor"] = comboBoxBackgroundColor.Text;
            if (comboBoxBackgroundColor.Text != "")
                ConfigurationManager.AppSettings["DownColor"] = comboBoxBackgroundColor.Text;
            this.Close();
        }
    }
}
