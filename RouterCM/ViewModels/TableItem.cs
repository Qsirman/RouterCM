using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace RouterCM.ViewModels
{
    public enum TableItemType
    {
        UNKNOWN = 255,
        PROJECT = 0,
        BOARD,
        PORT,
        DEV

    };
    public class TableItem
    {
        public string id { get; set; } = "1";
        public string name { get; set; } = "Ua";
        public string val_type { get; set; } = "电压";
        public string unit { get; set; } = "V";
        public int groupid { get; set; } = 0;
        public int no { get; set; } = 1;
        public double cc1 { get; set; } = 0.1;
        public double max { get; set; } = 9999;
        public double zero_val { get; set; } = 9999;
        public string limit_type { get; set; } = "绝对值";
        public double limit_min { get; set; } = 0.001;
        public string data_type { get; set; } = "16位整型";
        public string byte_order { get; set; } = "H1 H2";
        public int router_group { get; set; } = 1;
        public int router_addr { get; set; } = 0;
        public int code { get; set; } = 3;
        public int addr_bias { get; set; } = 0;
        public TableItemType ctrl_type = TableItemType.UNKNOWN;
        public TableItem() { }
        public TableItem(
string _id,
string _name,
string _val_type,
string _unit,
int _groupid,
int _no,
int _cc1,
double _max,
double _zero_val,
string _limit_type,
double _limit_min,
string _data_type,
string _byte_order,
int _router_group,
int _router_addr,
int _code,
int _addr_bias
) {
id = _id ;
name = _name ;
val_type = _val_type ;
unit = _unit ;
groupid = _groupid ;
no = _no ;
cc1 = _cc1 ;
max = _max ;
zero_val = _zero_val ;
limit_type = _limit_type ;
limit_min = _limit_min ;
data_type = _data_type ;
byte_order = _byte_order ;
router_group = _router_group ;
router_addr = _router_addr ;
code = _code ;
            addr_bias = _addr_bias;
        }
    }
}
