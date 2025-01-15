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
    public class TableItem
    {
        public int id = 0;
        public SortedList<string, string> args = new SortedList<string, string>();

        public TableItem()
        {
            args["Name"] = "UA";
        }
    }
}
