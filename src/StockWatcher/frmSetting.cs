using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace StockWatcher
{
    public partial class frmSetting : Form
    {
        private readonly StockPreviewControl userControl;
        public frmSetting(StockPreviewControl userControl)
        {
            InitializeComponent();
            this.userControl = userControl;
        }

        private void  loadMentionList()
        {
            var list1 = new List<string>();
            foreach(var item in StockConfig.goDownMentionList)
            {
                list1.Add(item.ToString("F2"));
            }
            this.goDownMentionList.Text = string.Join("\r\n", list1);
            var list2 = new List<string>();
            foreach (var item in StockConfig.goUpMentionList)
            {
                list2.Add(item.ToString("F2"));
            }
            this.goUpMentionList.Text = string.Join("\r\n", list2);
        }
        private void LoadStockList()
        {
            var list = (from a in StockConfig.StockList
                        select a.Substring(a.Length - 6)).ToList();
            this.textBoxStockList.Text = string.Join("\r\n", list);
            loadMentionList();
        }

        private void buttonForAddStock_Click(object sender, EventArgs e)
        {
            var input = Util.Input("请输入正确的股票代码：");
            var stockCode = Util.ReturnFixStockCode(input);
            if (stockCode == null)
            {
                Util.Error($"您输入的股票代码【{input}】不是正确的股票代码或已存在！");
                return;
            }
            if (StockConfig.AddStock(stockCode))
            {
                LoadStockList();
            }
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            var defaultInterval = (StockConfig.RefreshInterval / 1000).ToString();
            this.comboBoxForRefresh.SelectedItem = defaultInterval;

            LoadStockList();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (this.comboBoxForRefresh.SelectedItem == null)
            {
                Util.Alert("请选择刷新间隔！");
                return;
            }
            var refreshInterval = int.Parse(this.comboBoxForRefresh.SelectedItem.ToString());
            var stockList = this.textBoxStockList.Text.Trim();
            var goDownMentionList = this.goDownMentionList.Text.Trim();
            var goUpMentionList = this.goUpMentionList.Text.Trim();
            var arr = stockList.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var list = new List<string>();
            foreach (var item in arr)
            {
                var _code = Util.ReturnFixStockCode(item);
                if (string.IsNullOrEmpty(_code))
                {
                    Util.Alert($"您输入的股票代码【{item}】不是正确的代码，请检查！");
                    return;
                }
                list.Add(_code);
            }


            var downMentionList = new List<float>();
            arr = goDownMentionList.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arr)
            {
                if (string.IsNullOrEmpty(item))
                {
                    downMentionList.Add(0.0f);
                }
                float itemf;
                if(float.TryParse(item,out itemf))
                {
                    downMentionList.Add(itemf);
                }else
                {
                    Util.Alert($"您输入的目标价格【{item}】不是正确的数字，请检查！");
                }
            }
            var upMentionList = new List<float>();
            arr = goUpMentionList.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in arr)
            {

                if (string.IsNullOrEmpty(item))
                {
                    upMentionList.Add(0.0f);
                }
                float itemf;
                if (float.TryParse(item, out itemf))
                {
                    upMentionList.Add(itemf);
                }
                else
                {
                    Util.Alert($"您输入的目标价格【{item}】不是正确的数字，请检查！");
                }
            }

            StockConfig.RefreshInterval = refreshInterval;
            StockConfig.StockList = list;
            StockConfig.goDownMentionList = downMentionList;
            StockConfig.goUpMentionList = upMentionList;
            userControl.ResetTimer();
            Util.Alert("保存成功！");
            this.Close();
        }
    }
}
