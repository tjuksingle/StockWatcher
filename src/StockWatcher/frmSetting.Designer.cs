
namespace StockWatcher
{
    partial class frmSetting
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
            this.labelForRefresh = new System.Windows.Forms.Label();
            this.comboBoxForRefresh = new System.Windows.Forms.ComboBox();
            this.labelForList = new System.Windows.Forms.Label();
            this.textBoxStockList = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.goDownMentionList = new System.Windows.Forms.TextBox();
            this.goUpMentionList = new System.Windows.Forms.TextBox();
            this.stockCodeLabel = new System.Windows.Forms.Label();
            this.downSideTarget = new System.Windows.Forms.Label();
            this.upSideTarget = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelForRefresh
            // 
            this.labelForRefresh.AutoSize = true;
            this.labelForRefresh.Location = new System.Drawing.Point(9, 14);
            this.labelForRefresh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelForRefresh.Name = "labelForRefresh";
            this.labelForRefresh.Size = new System.Drawing.Size(101, 12);
            this.labelForRefresh.TabIndex = 3;
            this.labelForRefresh.Text = "刷新间隔（秒）：";
            // 
            // comboBoxForRefresh
            // 
            this.comboBoxForRefresh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxForRefresh.Items.AddRange(new object[] {
            "3",
            "5",
            "8",
            "10",
            "15"});
            this.comboBoxForRefresh.Location = new System.Drawing.Point(109, 12);
            this.comboBoxForRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxForRefresh.Name = "comboBoxForRefresh";
            this.comboBoxForRefresh.Size = new System.Drawing.Size(114, 20);
            this.comboBoxForRefresh.TabIndex = 4;
            // 
            // labelForList
            // 
            this.labelForList.AutoSize = true;
            this.labelForList.Location = new System.Drawing.Point(9, 46);
            this.labelForList.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelForList.Name = "labelForList";
            this.labelForList.Size = new System.Drawing.Size(197, 12);
            this.labelForList.TabIndex = 5;
            this.labelForList.Text = "监控列表（一行一个，一一对应）：";
            // 
            // textBoxStockList
            // 
            this.textBoxStockList.Location = new System.Drawing.Point(11, 98);
            this.textBoxStockList.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxStockList.Multiline = true;
            this.textBoxStockList.Name = "textBoxStockList";
            this.textBoxStockList.Size = new System.Drawing.Size(100, 175);
            this.textBoxStockList.TabIndex = 6;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(192, 279);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(85, 30);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "保存设置";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // goDownMentionList
            // 
            this.goDownMentionList.Location = new System.Drawing.Point(114, 98);
            this.goDownMentionList.Margin = new System.Windows.Forms.Padding(2);
            this.goDownMentionList.Multiline = true;
            this.goDownMentionList.Name = "goDownMentionList";
            this.goDownMentionList.Size = new System.Drawing.Size(80, 175);
            this.goDownMentionList.TabIndex = 8;
            // 
            // goUpMentionList
            // 
            this.goUpMentionList.Location = new System.Drawing.Point(197, 98);
            this.goUpMentionList.Margin = new System.Windows.Forms.Padding(2);
            this.goUpMentionList.Multiline = true;
            this.goUpMentionList.Name = "goUpMentionList";
            this.goUpMentionList.Size = new System.Drawing.Size(80, 175);
            this.goUpMentionList.TabIndex = 9;
            // 
            // stockCodeLabel
            // 
            this.stockCodeLabel.AutoSize = true;
            this.stockCodeLabel.Location = new System.Drawing.Point(9, 81);
            this.stockCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stockCodeLabel.Name = "stockCodeLabel";
            this.stockCodeLabel.Size = new System.Drawing.Size(65, 12);
            this.stockCodeLabel.TabIndex = 10;
            this.stockCodeLabel.Text = "股票代码：";
            // 
            // downSideTarget
            // 
            this.downSideTarget.AutoSize = true;
            this.downSideTarget.Location = new System.Drawing.Point(112, 81);
            this.downSideTarget.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.downSideTarget.Name = "downSideTarget";
            this.downSideTarget.Size = new System.Drawing.Size(77, 12);
            this.downSideTarget.TabIndex = 11;
            this.downSideTarget.Text = "下跌监控价：";
            // 
            // upSideTarget
            // 
            this.upSideTarget.AutoSize = true;
            this.upSideTarget.Location = new System.Drawing.Point(195, 81);
            this.upSideTarget.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.upSideTarget.Name = "upSideTarget";
            this.upSideTarget.Size = new System.Drawing.Size(77, 12);
            this.upSideTarget.TabIndex = 12;
            this.upSideTarget.Text = "上涨监控价：";
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 320);
            this.Controls.Add(this.upSideTarget);
            this.Controls.Add(this.downSideTarget);
            this.Controls.Add(this.stockCodeLabel);
            this.Controls.Add(this.goUpMentionList);
            this.Controls.Add(this.goDownMentionList);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxStockList);
            this.Controls.Add(this.labelForList);
            this.Controls.Add(this.comboBoxForRefresh);
            this.Controls.Add(this.labelForRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelForRefresh;
        private System.Windows.Forms.ComboBox comboBoxForRefresh;
        private System.Windows.Forms.Label labelForList;
        private System.Windows.Forms.TextBox textBoxStockList;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox goDownMentionList;
        private System.Windows.Forms.TextBox goUpMentionList;
        private System.Windows.Forms.Label stockCodeLabel;
        private System.Windows.Forms.Label downSideTarget;
        private System.Windows.Forms.Label upSideTarget;
    }
}