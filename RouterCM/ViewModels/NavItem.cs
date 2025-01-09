using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouterCM.ViewModels
{
    public enum CtrlType
    {
        UNKNOWN = 255,
        PROJECT = 0,
        BOARD,
        PORT,
        DEV

    };
    public class NavItem
    {
        public string name { get; set; } = "";
        public CtrlType ctrl_type = CtrlType.UNKNOWN;
        public NavItem() { }
        public NavItem(string _name, ObservableCollection<NavItem> children) { name = _name; Children = children; }
        public NavItem(string _name) { name = _name; }
        public ObservableCollection<NavItem> Children { get; } = new();
    }
}
