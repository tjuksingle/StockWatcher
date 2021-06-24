using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher
{
    static class StockConfig
    {
        internal const string CODE_SH_STOCK_NUMBER = "000001";
        internal const string CODE_SZ_STOCK_NUMBER = "399001";
        internal const string CODE_SH_STOCK = "s_sh" + CODE_SH_STOCK_NUMBER;
        internal const string CODE_SZ_STOCK = "s_sz" + CODE_SZ_STOCK_NUMBER;
        internal const string CODE_DOWNMENTION_NUMBER = "5";
        internal const string CODE_UPMENTION_NUMBER = "5";

        internal static string LOG_PATH;

        private static string CONFIG_PATH;
        private const string DEFAULT_REFRESH_INTERVAL = "5";
        private const string DEFAULT_SETTING =
            INI_PROPERTY_REFRESH_INTERVAL + "=" + DEFAULT_REFRESH_INTERVAL + "\r\n" +
            INI_PROPERTY_STOCK_LIST + "=" + CODE_SH_STOCK + "," + CODE_SZ_STOCK+"\r\n"+
            INI_PROPERTY_DOWNMENTION_LIST + "=" + CODE_DOWNMENTION_NUMBER+","+ CODE_DOWNMENTION_NUMBER+ " \r\n" +
            INI_PROPERTY_UPMENTION_LIST + "=" + CODE_UPMENTION_NUMBER+"," + CODE_UPMENTION_NUMBER;
        private const string INI_PROPERTY_STOCK_LIST = "STOCK_LIST";
        private const string INI_PROPERTY_REFRESH_INTERVAL = "REFRESH_INTERVAL";
        private const string INI_PROPERTY_DOWNMENTION_LIST = "DOWNMENTION_LIST";
        private const string INI_PROPERTY_UPMENTION_LIST = "UPMENTION_LIST";

        static StockConfig()
        {
            CONFIG_PATH = Path.Combine(Path.GetTempPath(), "stock_watcher_config.ini");
            LOG_PATH = Path.Combine(Path.GetTempPath(), "stock_watcher.log");
            LoadSetting();
        }

        private static void CheckSettingFile()
        {
            if (!File.Exists(CONFIG_PATH) || File.ReadAllText(CONFIG_PATH) == string.Empty)
            {
                File.WriteAllText(CONFIG_PATH, DEFAULT_SETTING);
            }
        }

        public static void LoadSetting()
        {
            CheckSettingFile();
            var stockListStr = INIHelper.Read(CONFIG_PATH, INI_PROPERTY_STOCK_LIST, $"{CODE_SH_STOCK},{CODE_SZ_STOCK}");
            if (_StockList == null)
            {
                _StockList = new List<string>();
            }
            _StockList.Clear();
            if (!string.IsNullOrEmpty(stockListStr))
            {
                _StockList.AddRange(from a in stockListStr.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    select a.Trim());
            }

            var downMentionList = INIHelper.Read(CONFIG_PATH, INI_PROPERTY_DOWNMENTION_LIST, $"{CODE_DOWNMENTION_NUMBER},{CODE_DOWNMENTION_NUMBER}");
            if (_GoDownMentionList == null)
            {
                _GoDownMentionList = new List<float>();
            }
            _GoDownMentionList.Clear();
            if (!string.IsNullOrEmpty(downMentionList))
            {
                _GoDownMentionList.AddRange(from a in downMentionList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                    select float.Parse(a.Trim()));
            }

            var upMentionList = INIHelper.Read(CONFIG_PATH, INI_PROPERTY_UPMENTION_LIST, $"{CODE_UPMENTION_NUMBER},{CODE_UPMENTION_NUMBER}");
            if (_GoUpMentionList == null)
            {
                _GoUpMentionList = new List<float>();
            }
            _GoUpMentionList.Clear();
            if (!string.IsNullOrEmpty(upMentionList))
            {
                _GoUpMentionList.AddRange(from a in upMentionList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                           select float.Parse(a.Trim()));
            }

            var refreshIntervalStr = INIHelper.Read(CONFIG_PATH, INI_PROPERTY_REFRESH_INTERVAL, DEFAULT_REFRESH_INTERVAL);
            int _refreshInterval;
            if (!int.TryParse(refreshIntervalStr, out _refreshInterval))
            {
                INIHelper.Write(CONFIG_PATH, INI_PROPERTY_REFRESH_INTERVAL, DEFAULT_REFRESH_INTERVAL);
            }
            _RefreshInterval = _refreshInterval;
        }


        private static List<string> _StockList = null;
        public static List<string> StockList
        {
            get
            {
                return _StockList;
            }
            set
            {
                if (value == null)
                {
                    _StockList = new List<string>();
                }
                else
                {
                    _StockList = value;
                }
                var codeList = string.Join(",", _StockList.Where(p => !string.IsNullOrEmpty(p)).Distinct().ToArray());
                if (string.IsNullOrEmpty(codeList))
                {
                    codeList = $"{CODE_SH_STOCK},{CODE_SZ_STOCK}";
                }
                INIHelper.Write(CONFIG_PATH, INI_PROPERTY_STOCK_LIST, codeList);
            }
        }

        private static void updateINIFileForDownMentionList()
        {
            var codeList = string.Join(",", _GoDownMentionList.Where(p => !string.IsNullOrEmpty(p.ToString())).ToArray());
            if (string.IsNullOrEmpty(codeList))
            {
                codeList = $"{CODE_DOWNMENTION_NUMBER},{CODE_DOWNMENTION_NUMBER}";
            }
            INIHelper.Write(CONFIG_PATH, INI_PROPERTY_DOWNMENTION_LIST, codeList);
        }

        private static List<float> _GoDownMentionList = null;
        public static List<float> goDownMentionList
        {
            get
            {
                return _GoDownMentionList;
            }
            set
            {
                if (value == null)
                {
                    _GoDownMentionList = new List<float>();
                }
                else
                {
                    _GoDownMentionList = value;
                }
                updateINIFileForDownMentionList();
            }
        }

        private static void updateINIFileForUpMentionList()
        {
            var codeList = string.Join(",", _GoUpMentionList.Where(p => !string.IsNullOrEmpty(p.ToString())).ToArray());
            if (string.IsNullOrEmpty(codeList))
            {
                codeList = $"{CODE_UPMENTION_NUMBER},{CODE_UPMENTION_NUMBER}";
            }
            INIHelper.Write(CONFIG_PATH, INI_PROPERTY_UPMENTION_LIST, codeList);
        }


        private static List<float> _GoUpMentionList = null;
        public static List<float> goUpMentionList
        {
            get
            {
                return _GoUpMentionList;
            }
            set
            {
                if (value == null)
                {
                    _GoUpMentionList = new List<float>();
                }
                else
                {
                    _GoUpMentionList = value;
                }
                updateINIFileForUpMentionList();
            }
        }

        public static bool AddStock(string code)
        {
            var stockList = new List<string>(StockList);
            if (stockList.Contains(code))
            {
                return false;
            }
            stockList.Add(code);
            StockList = new List<string>(stockList);
            return true;
        }


        public static void updateGoDownMentionList(int index, float content)
        {
            _GoDownMentionList[index] = content;
            updateINIFileForDownMentionList();
        }


        public static void updateGoUpMentionList(int index, float content)
        {
            _GoUpMentionList[index] = content;
            updateINIFileForUpMentionList();
        }

        private static int _RefreshInterval = 3;
        public static int RefreshInterval
        {
            get
            {
                return _RefreshInterval * 1000;
            }
            set
            {
                if (value <= 0)
                {
                    _RefreshInterval = 3;
                }
                else
                {
                    _RefreshInterval = value;
                }
                INIHelper.Write(CONFIG_PATH, INI_PROPERTY_REFRESH_INTERVAL, $"{_RefreshInterval}");
            }
        }
    }
}
