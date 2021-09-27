
namespace UI
{
    partial class BuySellUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelBuySellOrderWindow = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textBoxAucNo = new System.Windows.Forms.TextBox();
            this.textBoxMktProt = new System.Windows.Forms.TextBox();
            this.textBoxNoOfDays = new System.Windows.Forms.TextBox();
            this.comboBoxValidityDate = new System.Windows.Forms.ComboBox();
            this.comboBoxPartyCode = new System.Windows.Forms.ComboBox();
            this.comboBoxCliName = new System.Windows.Forms.ComboBox();
            this.comboBoxClientId = new System.Windows.Forms.ComboBox();
            this.comboBoxValidity = new System.Windows.Forms.ComboBox();
            this.comboBoxProdType = new System.Windows.Forms.ComboBox();
            this.textBoxDisQty = new System.Windows.Forms.TextBox();
            this.textBoxTrPrice = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBasket = new System.Windows.Forms.ComboBox();
            this.comboBoxExpiry = new System.Windows.Forms.ComboBox();
            this.comboBoxStrike = new System.Windows.Forms.ComboBox();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.comboBoxSymbol = new System.Windows.Forms.ComboBox();
            this.comboBoxInstrumentType = new System.Windows.Forms.ComboBox();
            this.comboBoxPro = new System.Windows.Forms.ComboBox();
            this.comboBoxOrderType = new System.Windows.Forms.ComboBox();
            this.comboBoxSegment = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.labelClose);
            this.panelHeader.Controls.Add(this.labelBuySellOrderWindow);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1024, 29);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            this.panelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseDown);
            this.panelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelHeader_MouseMove);
            // 
            // labelClose
            // 
            this.labelClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.Location = new System.Drawing.Point(1003, 4);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(18, 18);
            this.labelClose.TabIndex = 1;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            // 
            // labelBuySellOrderWindow
            // 
            this.labelBuySellOrderWindow.AutoSize = true;
            this.labelBuySellOrderWindow.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuySellOrderWindow.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelBuySellOrderWindow.Location = new System.Drawing.Point(25, 4);
            this.labelBuySellOrderWindow.Name = "labelBuySellOrderWindow";
            this.labelBuySellOrderWindow.Size = new System.Drawing.Size(113, 18);
            this.labelBuySellOrderWindow.TabIndex = 0;
            this.labelBuySellOrderWindow.Text = "Buy Order Entry";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(200)))));
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.buttonSubmit);
            this.panel1.Controls.Add(this.textBoxAucNo);
            this.panel1.Controls.Add(this.textBoxMktProt);
            this.panel1.Controls.Add(this.textBoxNoOfDays);
            this.panel1.Controls.Add(this.comboBoxValidityDate);
            this.panel1.Controls.Add(this.comboBoxPartyCode);
            this.panel1.Controls.Add(this.comboBoxCliName);
            this.panel1.Controls.Add(this.comboBoxClientId);
            this.panel1.Controls.Add(this.comboBoxValidity);
            this.panel1.Controls.Add(this.comboBoxProdType);
            this.panel1.Controls.Add(this.textBoxDisQty);
            this.panel1.Controls.Add(this.textBoxTrPrice);
            this.panel1.Controls.Add(this.textBoxPrice);
            this.panel1.Controls.Add(this.textBoxQty);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.comboBoxBasket);
            this.panel1.Controls.Add(this.comboBoxExpiry);
            this.panel1.Controls.Add(this.comboBoxStrike);
            this.panel1.Controls.Add(this.comboBoxType);
            this.panel1.Controls.Add(this.comboBoxSymbol);
            this.panel1.Controls.Add(this.comboBoxInstrumentType);
            this.panel1.Controls.Add(this.comboBoxPro);
            this.panel1.Controls.Add(this.comboBoxOrderType);
            this.panel1.Controls.Add(this.comboBoxSegment);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 107);
            this.panel1.TabIndex = 1;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(978, 52);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(31, 13);
            this.label22.TabIndex = 44;
            this.label22.Text = "Days";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(871, 52);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 13);
            this.label21.TabIndex = 43;
            this.label21.Text = "Validity";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(752, 52);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(85, 13);
            this.label20.TabIndex = 42;
            this.label20.Text = "Participent Code";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(622, 52);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(64, 13);
            this.label19.TabIndex = 41;
            this.label19.Text = "Client Name";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(534, 52);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 13);
            this.label18.TabIndex = 40;
            this.label18.Text = "Client Id";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(460, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(40, 13);
            this.label17.TabIndex = 39;
            this.label17.Text = "Validity";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(370, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 13);
            this.label16.TabIndex = 38;
            this.label16.Text = "Prod Type";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(272, 52);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Disc. Qty";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(168, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 13);
            this.label14.TabIndex = 36;
            this.label14.Text = "Tr. Price";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(87, 52);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(31, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Price";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 34;
            this.label12.Text = "Qty";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(871, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Auc No";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(803, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Mkt Prot";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(958, 18);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(61, 23);
            this.buttonSubmit.TabIndex = 31;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // textBoxAucNo
            // 
            this.textBoxAucNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxAucNo.Location = new System.Drawing.Point(874, 20);
            this.textBoxAucNo.Name = "textBoxAucNo";
            this.textBoxAucNo.Size = new System.Drawing.Size(78, 21);
            this.textBoxAucNo.TabIndex = 30;
            // 
            // textBoxMktProt
            // 
            this.textBoxMktProt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMktProt.Location = new System.Drawing.Point(806, 20);
            this.textBoxMktProt.Name = "textBoxMktProt";
            this.textBoxMktProt.Size = new System.Drawing.Size(62, 21);
            this.textBoxMktProt.TabIndex = 29;
            // 
            // textBoxNoOfDays
            // 
            this.textBoxNoOfDays.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNoOfDays.Location = new System.Drawing.Point(978, 68);
            this.textBoxNoOfDays.Name = "textBoxNoOfDays";
            this.textBoxNoOfDays.Size = new System.Drawing.Size(41, 21);
            this.textBoxNoOfDays.TabIndex = 28;
            // 
            // comboBoxValidityDate
            // 
            this.comboBoxValidityDate.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxValidityDate.Enabled = false;
            this.comboBoxValidityDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxValidityDate.FormattingEnabled = true;
            this.comboBoxValidityDate.Location = new System.Drawing.Point(874, 68);
            this.comboBoxValidityDate.Name = "comboBoxValidityDate";
            this.comboBoxValidityDate.Size = new System.Drawing.Size(98, 21);
            this.comboBoxValidityDate.TabIndex = 27;
            // 
            // comboBoxPartyCode
            // 
            this.comboBoxPartyCode.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxPartyCode.Enabled = false;
            this.comboBoxPartyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPartyCode.FormattingEnabled = true;
            this.comboBoxPartyCode.Location = new System.Drawing.Point(755, 68);
            this.comboBoxPartyCode.Name = "comboBoxPartyCode";
            this.comboBoxPartyCode.Size = new System.Drawing.Size(113, 21);
            this.comboBoxPartyCode.TabIndex = 26;
            // 
            // comboBoxCliName
            // 
            this.comboBoxCliName.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxCliName.Enabled = false;
            this.comboBoxCliName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCliName.FormattingEnabled = true;
            this.comboBoxCliName.Location = new System.Drawing.Point(625, 68);
            this.comboBoxCliName.Name = "comboBoxCliName";
            this.comboBoxCliName.Size = new System.Drawing.Size(124, 21);
            this.comboBoxCliName.TabIndex = 25;
            // 
            // comboBoxClientId
            // 
            this.comboBoxClientId.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxClientId.Enabled = false;
            this.comboBoxClientId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxClientId.FormattingEnabled = true;
            this.comboBoxClientId.Location = new System.Drawing.Point(535, 68);
            this.comboBoxClientId.Name = "comboBoxClientId";
            this.comboBoxClientId.Size = new System.Drawing.Size(84, 21);
            this.comboBoxClientId.TabIndex = 24;
            // 
            // comboBoxValidity
            // 
            this.comboBoxValidity.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxValidity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxValidity.FormattingEnabled = true;
            this.comboBoxValidity.Location = new System.Drawing.Point(463, 68);
            this.comboBoxValidity.Name = "comboBoxValidity";
            this.comboBoxValidity.Size = new System.Drawing.Size(65, 21);
            this.comboBoxValidity.TabIndex = 23;
            // 
            // comboBoxProdType
            // 
            this.comboBoxProdType.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxProdType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxProdType.FormattingEnabled = true;
            this.comboBoxProdType.Location = new System.Drawing.Point(373, 68);
            this.comboBoxProdType.Name = "comboBoxProdType";
            this.comboBoxProdType.Size = new System.Drawing.Size(84, 21);
            this.comboBoxProdType.TabIndex = 22;
            // 
            // textBoxDisQty
            // 
            this.textBoxDisQty.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxDisQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDisQty.Location = new System.Drawing.Point(272, 68);
            this.textBoxDisQty.Name = "textBoxDisQty";
            this.textBoxDisQty.Size = new System.Drawing.Size(95, 21);
            this.textBoxDisQty.TabIndex = 21;
            // 
            // textBoxTrPrice
            // 
            this.textBoxTrPrice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.textBoxTrPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTrPrice.Location = new System.Drawing.Point(171, 68);
            this.textBoxTrPrice.Name = "textBoxTrPrice";
            this.textBoxTrPrice.Size = new System.Drawing.Size(95, 21);
            this.textBoxTrPrice.TabIndex = 20;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrice.Location = new System.Drawing.Point(87, 68);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(78, 21);
            this.textBoxPrice.TabIndex = 19;
            // 
            // textBoxQty
            // 
            this.textBoxQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxQty.Location = new System.Drawing.Point(3, 68);
            this.textBoxQty.Name = "textBoxQty";
            this.textBoxQty.Size = new System.Drawing.Size(78, 21);
            this.textBoxQty.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(684, 3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Basket-Weve-Line";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(584, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Expiry";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(494, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Strike";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(441, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Type";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(337, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Symbol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Inst Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Pro/Cli";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Order Type";
            // 
            // comboBoxBasket
            // 
            this.comboBoxBasket.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxBasket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxBasket.FormattingEnabled = true;
            this.comboBoxBasket.Location = new System.Drawing.Point(687, 20);
            this.comboBoxBasket.Name = "comboBoxBasket";
            this.comboBoxBasket.Size = new System.Drawing.Size(113, 21);
            this.comboBoxBasket.TabIndex = 9;
            // 
            // comboBoxExpiry
            // 
            this.comboBoxExpiry.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxExpiry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxExpiry.FormattingEnabled = true;
            this.comboBoxExpiry.Location = new System.Drawing.Point(587, 20);
            this.comboBoxExpiry.Name = "comboBoxExpiry";
            this.comboBoxExpiry.Size = new System.Drawing.Size(94, 21);
            this.comboBoxExpiry.TabIndex = 8;
            this.comboBoxExpiry.SelectedIndexChanged += new System.EventHandler(this.comboBoxExpiry_SelectedIndexChanged);
            // 
            // comboBoxStrike
            // 
            this.comboBoxStrike.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxStrike.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxStrike.FormattingEnabled = true;
            this.comboBoxStrike.Location = new System.Drawing.Point(497, 20);
            this.comboBoxStrike.Name = "comboBoxStrike";
            this.comboBoxStrike.Size = new System.Drawing.Size(84, 21);
            this.comboBoxStrike.TabIndex = 7;
            this.comboBoxStrike.SelectedIndexChanged += new System.EventHandler(this.comboBoxStrike_SelectedIndexChanged);
            // 
            // comboBoxType
            // 
            this.comboBoxType.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(444, 20);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(47, 21);
            this.comboBoxType.TabIndex = 6;
            this.comboBoxType.SelectedIndexChanged += new System.EventHandler(this.comboBoxType_SelectedIndexChanged);
            // 
            // comboBoxSymbol
            // 
            this.comboBoxSymbol.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBoxSymbol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSymbol.FormattingEnabled = true;
            this.comboBoxSymbol.Location = new System.Drawing.Point(340, 20);
            this.comboBoxSymbol.Name = "comboBoxSymbol";
            this.comboBoxSymbol.Size = new System.Drawing.Size(98, 21);
            this.comboBoxSymbol.TabIndex = 5;
            this.comboBoxSymbol.SelectedIndexChanged += new System.EventHandler(this.comboBoxSymbol_SelectedIndexChanged);
            // 
            // comboBoxInstrumentType
            // 
            this.comboBoxInstrumentType.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.comboBoxInstrumentType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxInstrumentType.FormattingEnabled = true;
            this.comboBoxInstrumentType.Location = new System.Drawing.Point(236, 20);
            this.comboBoxInstrumentType.Name = "comboBoxInstrumentType";
            this.comboBoxInstrumentType.Size = new System.Drawing.Size(98, 21);
            this.comboBoxInstrumentType.TabIndex = 4;
            this.comboBoxInstrumentType.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstrumentType_SelectedIndexChanged);
            // 
            // comboBoxPro
            // 
            this.comboBoxPro.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxPro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPro.FormattingEnabled = true;
            this.comboBoxPro.Location = new System.Drawing.Point(171, 20);
            this.comboBoxPro.Name = "comboBoxPro";
            this.comboBoxPro.Size = new System.Drawing.Size(59, 21);
            this.comboBoxPro.TabIndex = 3;
            // 
            // comboBoxOrderType
            // 
            this.comboBoxOrderType.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxOrderType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxOrderType.FormattingEnabled = true;
            this.comboBoxOrderType.Location = new System.Drawing.Point(87, 20);
            this.comboBoxOrderType.Name = "comboBoxOrderType";
            this.comboBoxOrderType.Size = new System.Drawing.Size(78, 21);
            this.comboBoxOrderType.TabIndex = 2;
            this.comboBoxOrderType.SelectedIndexChanged += new System.EventHandler(this.comboBoxOrderType_SelectedIndexChanged);
            // 
            // comboBoxSegment
            // 
            this.comboBoxSegment.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.comboBoxSegment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxSegment.FormattingEnabled = true;
            this.comboBoxSegment.Location = new System.Drawing.Point(3, 20);
            this.comboBoxSegment.Name = "comboBoxSegment";
            this.comboBoxSegment.Size = new System.Drawing.Size(78, 21);
            this.comboBoxSegment.TabIndex = 1;
            this.comboBoxSegment.SelectedIndexChanged += new System.EventHandler(this.comboBoxSegment_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Exhg-Seg";
            // 
            // BuySellUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelHeader);
            this.Name = "BuySellUserControl";
            this.Size = new System.Drawing.Size(1024, 136);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label labelBuySellOrderWindow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textBoxAucNo;
        private System.Windows.Forms.TextBox textBoxMktProt;
        private System.Windows.Forms.TextBox textBoxNoOfDays;
        private System.Windows.Forms.ComboBox comboBoxValidityDate;
        private System.Windows.Forms.ComboBox comboBoxPartyCode;
        private System.Windows.Forms.ComboBox comboBoxCliName;
        private System.Windows.Forms.ComboBox comboBoxClientId;
        private System.Windows.Forms.ComboBox comboBoxValidity;
        private System.Windows.Forms.ComboBox comboBoxProdType;
        private System.Windows.Forms.TextBox textBoxDisQty;
        private System.Windows.Forms.TextBox textBoxTrPrice;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxQty;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBasket;
        private System.Windows.Forms.ComboBox comboBoxExpiry;
        private System.Windows.Forms.ComboBox comboBoxStrike;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxSymbol;
        private System.Windows.Forms.ComboBox comboBoxInstrumentType;
        private System.Windows.Forms.ComboBox comboBoxPro;
        private System.Windows.Forms.ComboBox comboBoxOrderType;
        private System.Windows.Forms.ComboBox comboBoxSegment;
        private System.Windows.Forms.Label label1;
    }
}
