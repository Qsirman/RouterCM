using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using CommunityToolkit.Mvvm.Input;

using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using RouterCM.ViewModels;

namespace RouterCM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string Greeting { get; } = "Welcome to Avalonia!";
        public string Greeting2 { get; } = "Welcome to Avalonia2!";

        public ICommand NewCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand ExitCommand { get; }

        public ICommand UndoCommand { get; }
        public ICommand RedoCommand { get; }
        public ICommand CutCommand { get; }
        public ICommand CopyCommand { get; }
        public ICommand PasteCommand { get; }

        public ICommand AboutCommand { get; }

        public MainWindowViewModel()
        {
            NewCommand = new RelayCommand(OnNew);
            OpenCommand = new RelayCommand(OnOpen);
            SaveCommand = new RelayCommand(OnSave);
            SaveAsCommand = new RelayCommand(OnSaveAs);
            ExitCommand = new RelayCommand(OnExit);

            UndoCommand = new RelayCommand(OnUndo);
            RedoCommand = new RelayCommand(OnRedo);
            CutCommand = new RelayCommand(OnCut);
            CopyCommand = new RelayCommand(OnCopy);
            PasteCommand = new RelayCommand(OnPaste);

            AboutCommand = new RelayCommand(OnAbout);

            //NavItemGroup = new ObservableCollection<NavItem>(FillNavItem());

            NavItems = new ObservableCollection<NavItem>
            {
                new NavItem("项目组", new ObservableCollection<NavItem>{
                    new NavItem("测试", new ObservableCollection<NavItem>{
                      new NavItem("安岳箱变", new ObservableCollection<NavItem>{
                          new NavItem("ANet-2E4S1[00037686090068]", new ObservableCollection<NavItem>{
                            new NavItem("主模块", new ObservableCollection<NavItem>{
                                new NavItem("串口1", new ObservableCollection<NavItem>{
                                    new NavItem("多功能仪表（PM）[HZ194E-9SY]"),
                                    new NavItem("多功能仪表（5PM）[HZ194E-9SY]"),
                                    new NavItem("多功能仪表（6PM）[HZ194E-9SY]"),
                                    new NavItem("多功能仪表（7PM）[HZ194E-9SY]"),
                                }),
                                new NavItem("串口2", new ObservableCollection<NavItem>{
                                    new NavItem("相变温湿度传感器[DL-XB3W1S]"),
                                }),
                                new NavItem("串口3", new ObservableCollection<NavItem>{
                                    new NavItem("遥信单元1[222]"),
                                    new NavItem("遥信单元2[222]"),
                                }),
                                new NavItem("串口4", new ObservableCollection<NavItem>{
                                    new NavItem("干变温控器[YK-BWDK130C]"),
                                }),
                            }),
                          }),
                      }),
                    }),
                }),
            };

            TableItems = new()
            {
                new TableItem(),
                new TableItem(),
            };

            Source = new FlatTreeDataGridSource<TableItem>(TableItems)
            {
                Columns =
            {
                    new TextColumn<TableItem, string>("ID", x => x.id),
                    new TextColumn<TableItem, string>("名称", x => x.name),
                    new TextColumn<TableItem, string>("类型", x => x.val_type),
                    new TextColumn<TableItem, string>("单位", x => x.unit),
                    new TextColumn<TableItem, int>("组号", x => x.groupid),
                    new TextColumn<TableItem, int>("序号", x => x.no),
                    new TextColumn<TableItem, double>("CC1", x => x.cc1),
                    new TextColumn<TableItem, double>("Max", x => x.max),
                    new TextColumn<TableItem, double>("归零值", x => x.zero_val),
                    new TextColumn<TableItem, string>("限值方式", x => x.limit_type),
                    new TextColumn<TableItem, double>("最小限值", x => x.limit_min),
                    new TextColumn<TableItem, string>("数据类型", x => x.data_type),
                    new TextColumn<TableItem, string>("数据字节序", x => x.byte_order),
                    new TextColumn<TableItem, int>("转发分组", x => x.router_group),
                    new TextColumn<TableItem, int>("转发地址", x => x.router_addr),
                    new TextColumn<TableItem, int>("功能码", x => x.code),
                    new TextColumn<TableItem, int>("偏移地址", x => x.addr_bias),
            },
            };
        }
        public ObservableCollection<NavItem> NavItems { get; }
        public ObservableCollection<TableItem> TableItems { get; set; }
        public FlatTreeDataGridSource<TableItem> Source { get; }

        private List<NavItem> FillNavItem()
        {
            //Fill league data here...
            return new List<NavItem>();
        }

        private void OnNew() { /* 新建逻辑 */ }
        private void OnOpen() { /* 打开逻辑 */ }
        private void OnSave() { /* 保存逻辑 */ }
        private void OnSaveAs() { /* 另存为逻辑 */ }
        private void OnExit() { /* 退出逻辑 */ }
        private void OnUndo() { /* 撤销逻辑 */ }
        private void OnRedo() { /* 重做逻辑 */ }
        private void OnCut() { /* 剪切逻辑 */ }
        private void OnCopy() { /* 复制逻辑 */ }
        private void OnPaste() { /* 粘贴逻辑 */ }
        private void OnAbout() { /* 关于逻辑 */ }
    }


}
