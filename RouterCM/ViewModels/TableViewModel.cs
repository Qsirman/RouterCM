using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace RouterCM.ViewModels
{
    public enum DataCategory
    {
        Unknown = -1,
        YC,// 遥测
        YX,// 遥信
        YM,// 遥脉
        YK,// 遥控
        YT,// 遥调
    };
    public class TableItem
    {
        public int id = 0;
        public SortedList<string, string> args = new SortedList<string, string>();

        public TableItem()
        {
            args["Name"] = "UA";
        }
    }

    public class TableViewModel
    {
        public ObservableCollection<TableItem> Items { get; } = new();
        public TableViewModel()
        {
            Items.Add(new TableItem());
        }
    }
}
