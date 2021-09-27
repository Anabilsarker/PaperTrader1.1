
namespace UI
{
    partial class OrderBookForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderBookForm));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.buttonFilterOrders = new System.Windows.Forms.Button();
            this.buttonShowFilters = new System.Windows.Forms.Button();
            this.checkBoxDisplayAll = new System.Windows.Forms.CheckBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelNQ = new System.Windows.Forms.Label();
            this.labelNV = new System.Windows.Forms.Label();
            this.labelSQ = new System.Windows.Forms.Label();
            this.labelSV = new System.Windows.Forms.Label();
            this.labelBV = new System.Windows.Forms.Label();
            this.labelBQ = new System.Windows.Forms.Label();
            this.buttonModify = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonCancelAll = new System.Windows.Forms.Button();
            this.buttonDisplay = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panelHeader.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.buttonFilterOrders);
            this.panelHeader.Controls.Add(this.buttonShowFilters);
            this.panelHeader.Controls.Add(this.checkBoxDisplayAll);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(966, 38);
            this.panelHeader.TabIndex = 0;
            // 
            // buttonFilterOrders
            // 
            this.buttonFilterOrders.Location = new System.Drawing.Point(258, 9);
            this.buttonFilterOrders.Name = "buttonFilterOrders";
            this.buttonFilterOrders.Size = new System.Drawing.Size(75, 23);
            this.buttonFilterOrders.TabIndex = 2;
            this.buttonFilterOrders.Text = "Filter orders";
            this.buttonFilterOrders.UseVisualStyleBackColor = true;
            // 
            // buttonShowFilters
            // 
            this.buttonShowFilters.Location = new System.Drawing.Point(165, 9);
            this.buttonShowFilters.Name = "buttonShowFilters";
            this.buttonShowFilters.Size = new System.Drawing.Size(75, 23);
            this.buttonShowFilters.TabIndex = 1;
            this.buttonShowFilters.Text = "ShowFilters";
            this.buttonShowFilters.UseVisualStyleBackColor = true;
            // 
            // checkBoxDisplayAll
            // 
            this.checkBoxDisplayAll.AutoSize = true;
            this.checkBoxDisplayAll.Location = new System.Drawing.Point(4, 15);
            this.checkBoxDisplayAll.Name = "checkBoxDisplayAll";
            this.checkBoxDisplayAll.Size = new System.Drawing.Size(109, 17);
            this.checkBoxDisplayAll.TabIndex = 0;
            this.checkBoxDisplayAll.Text = "Desplay all orders";
            this.checkBoxDisplayAll.UseVisualStyleBackColor = true;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.groupBox1);
            this.panelBottom.Controls.Add(this.buttonModify);
            this.panelBottom.Controls.Add(this.buttonCancel);
            this.panelBottom.Controls.Add(this.buttonExit);
            this.panelBottom.Controls.Add(this.buttonCancelAll);
            this.panelBottom.Controls.Add(this.buttonDisplay);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 372);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(966, 78);
            this.panelBottom.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelNQ);
            this.groupBox1.Controls.Add(this.labelNV);
            this.groupBox1.Controls.Add(this.labelSQ);
            this.groupBox1.Controls.Add(this.labelSV);
            this.groupBox1.Controls.Add(this.labelBV);
            this.groupBox1.Controls.Add(this.labelBQ);
            this.groupBox1.Location = new System.Drawing.Point(12, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(942, 26);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // labelNQ
            // 
            this.labelNQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNQ.ForeColor = System.Drawing.Color.Blue;
            this.labelNQ.Location = new System.Drawing.Point(786, 8);
            this.labelNQ.Name = "labelNQ";
            this.labelNQ.Size = new System.Drawing.Size(150, 15);
            this.labelNQ.TabIndex = 5;
            this.labelNQ.Text = "NQ : 0";
            // 
            // labelNV
            // 
            this.labelNV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelNV.ForeColor = System.Drawing.Color.Blue;
            this.labelNV.Location = new System.Drawing.Point(630, 8);
            this.labelNV.Name = "labelNV";
            this.labelNV.Size = new System.Drawing.Size(150, 15);
            this.labelNV.TabIndex = 4;
            this.labelNV.Text = "NV : 0";
            this.labelNV.Click += new System.EventHandler(this.labelNV_Click);
            // 
            // labelSQ
            // 
            this.labelSQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSQ.ForeColor = System.Drawing.Color.Red;
            this.labelSQ.Location = new System.Drawing.Point(474, 8);
            this.labelSQ.Name = "labelSQ";
            this.labelSQ.Size = new System.Drawing.Size(150, 15);
            this.labelSQ.TabIndex = 3;
            this.labelSQ.Text = "SQ : 0";
            // 
            // labelSV
            // 
            this.labelSV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelSV.ForeColor = System.Drawing.Color.Red;
            this.labelSV.Location = new System.Drawing.Point(318, 8);
            this.labelSV.Name = "labelSV";
            this.labelSV.Size = new System.Drawing.Size(150, 15);
            this.labelSV.TabIndex = 2;
            this.labelSV.Text = "SV : 0";
            // 
            // labelBV
            // 
            this.labelBV.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBV.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelBV.Location = new System.Drawing.Point(162, 8);
            this.labelBV.Name = "labelBV";
            this.labelBV.Size = new System.Drawing.Size(150, 15);
            this.labelBV.TabIndex = 1;
            this.labelBV.Text = "BV : 0";
            // 
            // labelBQ
            // 
            this.labelBQ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelBQ.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelBQ.Location = new System.Drawing.Point(6, 8);
            this.labelBQ.Name = "labelBQ";
            this.labelBQ.Size = new System.Drawing.Size(150, 15);
            this.labelBQ.TabIndex = 0;
            this.labelBQ.Text = "BQ : 0";
            // 
            // buttonModify
            // 
            this.buttonModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModify.Location = new System.Drawing.Point(590, 22);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(75, 23);
            this.buttonModify.TabIndex = 4;
            this.buttonModify.Text = "Modify";
            this.buttonModify.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(684, 22);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Enabled = false;
            this.buttonExit.Location = new System.Drawing.Point(780, 22);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            // 
            // buttonCancelAll
            // 
            this.buttonCancelAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancelAll.Location = new System.Drawing.Point(879, 22);
            this.buttonCancelAll.Name = "buttonCancelAll";
            this.buttonCancelAll.Size = new System.Drawing.Size(75, 23);
            this.buttonCancelAll.TabIndex = 1;
            this.buttonCancelAll.Text = "Cancel All";
            this.buttonCancelAll.UseVisualStyleBackColor = true;
            this.buttonCancelAll.Click += new System.EventHandler(this.buttonCancelAll_Click);
            // 
            // buttonDisplay
            // 
            this.buttonDisplay.Location = new System.Drawing.Point(12, 22);
            this.buttonDisplay.Name = "buttonDisplay";
            this.buttonDisplay.Size = new System.Drawing.Size(75, 23);
            this.buttonDisplay.TabIndex = 0;
            this.buttonDisplay.Text = "Display";
            this.buttonDisplay.UseVisualStyleBackColor = true;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.splitContainer1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 38);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(966, 334);
            this.panelMain.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer1.Size = new System.Drawing.Size(966, 334);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 0;
            // 
            // OrderBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 450);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderBookForm";
            this.Text = "OrderBookForm";
            this.Load += new System.EventHandler(this.OrderBookForm_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBottom.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button buttonFilterOrders;
        private System.Windows.Forms.Button buttonShowFilters;
        private System.Windows.Forms.CheckBox checkBoxDisplayAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelNV;
        private System.Windows.Forms.Label labelSQ;
        private System.Windows.Forms.Label labelSV;
        private System.Windows.Forms.Label labelBV;
        private System.Windows.Forms.Label labelBQ;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonCancelAll;
        private System.Windows.Forms.Button buttonDisplay;
        private System.Windows.Forms.Label labelNQ;
    }
}