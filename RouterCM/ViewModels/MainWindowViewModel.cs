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
using Avalonia.Interactivity;
using Tmds.DBus.Protocol;

using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Styling;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ReactiveUI;
using System;

namespace RouterCM.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        // This event is implemented by "INotifyPropertyChanged" and is all we need to inform
        // our view about changes.
        public event PropertyChangedEventHandler? PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Greeting { get; } = "Welcome to Avalonia!";
        public string Greeting2 { get; } = "Welcome to Avalonia2!";


        private string? _TableTitle;
        public string? TableTitle { get { return _TableTitle; } set { this.RaiseAndSetIfChanged(ref _TableTitle, value); } }
        public ObservableCollection<TabItem> tabitems { get; set; }

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

        public void set1(string str)
        {
            TableTitle = str;
        }

        public MainWindowViewModel()
        {
            TableTitle = "123";
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
                new TableItemYC(),
                new TableItemYC(),
            };

            Source = new FlatTreeDataGridSource<TableItemYC>(TableItems)
            {
                Columns =
                {
                    new TextColumn<TableItemYC, string>("ID", x => x.id),
                    new TextColumn<TableItemYC, string>("名称", x => x.name),
                    new TextColumn<TableItemYC, string>("类型", x => x.val_type),
                    new TextColumn<TableItemYC, string>("单位", x => x.unit),
                    new TextColumn<TableItemYC, int>("组号", x => x.groupid),
                    new TextColumn<TableItemYC, int>("序号", x => x.no),
                    new TextColumn<TableItemYC, double>("CC1", x => x.cc1),
                    new TextColumn<TableItemYC, double>("Max", x => x.max),
                    new TextColumn<TableItemYC, double>("归零值", x => x.zero_val),
                    new TextColumn<TableItemYC, string>("限值方式", x => x.limit_type),
                    new TextColumn<TableItemYC, double>("最小限值", x => x.limit_min),
                    new TextColumn<TableItemYC, string>("数据类型", x => x.data_type),
                    new TextColumn<TableItemYC, string>("数据字节序", x => x.byte_order),
                    new TextColumn<TableItemYC, int>("转发分组", x => x.router_group),
                    new TextColumn<TableItemYC, int>("转发地址", x => x.router_addr),
                    new TextColumn<TableItemYC, int>("功能码", x => x.code),
                    new TextColumn<TableItemYC, int>("偏移地址", x => x.addr_bias),
                },
            };

            tabitems = new ObservableCollection<TabItem>();
            tabitems.Add(new TabItem { Header = "遥测" });
            tabitems.Add(new TabItem { Header = "遥信" });
            tabitems.Add(new TabItem { Header = "遥脉" });
            tabitems.Add(new TabItem { Header = "遥控" });
            tabitems.Add(new TabItem { Header = "遥调" });

            // We can listen to any property changes with "WhenAnyValue" and do whatever we want in "Subscribe".
            this.WhenAnyValue(o => o.TableTitle)
                .Subscribe(o => this.RaisePropertyChanged(nameof(TableTitle)));
        }

        public ObservableCollection<NavItem> NavItems { get; }
        public ObservableCollection<TableItemYC> TableItems { get; set; }
        public FlatTreeDataGridSource<TableItemYC> Source { get; set; }

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




        public void _parentTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // TabControl tabcontrol = this.FindControl<TabControl>("tabcontrol");
            // TableTitle = tabcontrol.SelectedIndex.ToString();
            // if (this.IsVisible)
            //     MessageBoxManager.GetMessageBoxStandard("Caption", $"TableTitle = {TableTitle}",
            //ButtonEnum.Ok).ShowWindowDialogAsync(this);
            // switch (tabcontrol.SelectedIndex)
            // {
            //     case 0:
            //         {
            //             Source = new FlatTreeDataGridSource<TableItemYC>(TableItems)
            //             {
            //                 Columns =
            //             {
            //                 new TextColumn<TableItemYC, string>("ID0", x => x.id),
            //                 new TextColumn<TableItemYC, string>("名称", x => x.name),
            //                 new TextColumn<TableItemYC, string>("类型", x => x.val_type),
            //                 new TextColumn<TableItemYC, string>("单位", x => x.unit),
            //                 new TextColumn<TableItemYC, int>("组号", x => x.groupid),
            //                 new TextColumn<TableItemYC, int>("序号", x => x.no),
            //                 new TextColumn<TableItemYC, double>("CC1", x => x.cc1),
            //                 new TextColumn<TableItemYC, double>("Max", x => x.max),
            //                 new TextColumn<TableItemYC, double>("归零值", x => x.zero_val),
            //                 new TextColumn<TableItemYC, string>("限值方式", x => x.limit_type),
            //                 new TextColumn<TableItemYC, double>("最小限值", x => x.limit_min),
            //                 new TextColumn<TableItemYC, string>("数据类型", x => x.data_type),
            //                 new TextColumn<TableItemYC, string>("数据字节序", x => x.byte_order),
            //                 new TextColumn<TableItemYC, int>("转发分组", x => x.router_group),
            //                 new TextColumn<TableItemYC, int>("转发地址", x => x.router_addr),
            //                 new TextColumn<TableItemYC, int>("功能码", x => x.code),
            //                 new TextColumn<TableItemYC, int>("偏移地址", x => x.addr_bias),
            //             },
            //             };
            //             break;
            //         }

            //     case 1:
            //         {
            //             Source.Columns.Clear();
            //             //     Source = new FlatTreeDataGridSource<TableItemYC>(TableItems)
            //             //     {
            //             //         Columns =
            //             //     {
            //             //         new TextColumn<TableItemYC, string>("ID1", x => x.id),
            //             //         new TextColumn<TableItemYC, string>("名称", x => x.name),
            //             //         new TextColumn<TableItemYC, string>("类型", x => x.val_type),
            //             //         new TextColumn<TableItemYC, string>("单位", x => x.unit),
            //             //         new TextColumn<TableItemYC, int>("组号", x => x.groupid),
            //             //         new TextColumn<TableItemYC, int>("序号", x => x.no),
            //             //         new TextColumn<TableItemYC, double>("CC1", x => x.cc1),
            //             //         new TextColumn<TableItemYC, double>("Max", x => x.max),
            //             //         new TextColumn<TableItemYC, double>("归零值", x => x.zero_val),
            //             //         new TextColumn<TableItemYC, string>("限值方式", x => x.limit_type),
            //             //         new TextColumn<TableItemYC, double>("最小限值", x => x.limit_min),
            //             //         new TextColumn<TableItemYC, string>("数据类型", x => x.data_type),
            //             //         new TextColumn<TableItemYC, string>("数据字节序", x => x.byte_order),
            //             //         new TextColumn<TableItemYC, int>("转发分组", x => x.router_group),
            //             //         new TextColumn<TableItemYC, int>("转发地址", x => x.router_addr),
            //             //         new TextColumn<TableItemYC, int>("功能码", x => x.code),
            //             //         new TextColumn<TableItemYC, int>("偏移地址", x => x.addr_bias),
            //             //     },
            //             //     };
            //             //     MessageBoxManager.GetMessageBoxStandard("Caption", $"current sleect: {tabcontrol.SelectedIndex}",
            //             //ButtonEnum.Ok).ShowWindowDialogAsync(this);
            //             break;
            //         }
            //     case 2:
            //         {
            //             Source = new FlatTreeDataGridSource<TableItemYC>(TableItems)
            //             {
            //                 Columns =
            //             {
            //                 new TextColumn<TableItemYC, string>("ID2", x => x.id),
            //                 new TextColumn<TableItemYC, string>("名称", x => x.name),
            //                 new TextColumn<TableItemYC, string>("类型", x => x.val_type),
            //                 new TextColumn<TableItemYC, string>("单位", x => x.unit),
            //                 new TextColumn<TableItemYC, int>("组号", x => x.groupid),
            //                 new TextColumn<TableItemYC, int>("序号", x => x.no),
            //                 new TextColumn<TableItemYC, double>("CC1", x => x.cc1),
            //                 new TextColumn<TableItemYC, double>("Max", x => x.max),
            //                 new TextColumn<TableItemYC, double>("归零值", x => x.zero_val),
            //                 new TextColumn<TableItemYC, string>("限值方式", x => x.limit_type),
            //                 new TextColumn<TableItemYC, double>("最小限值", x => x.limit_min),
            //                 new TextColumn<TableItemYC, string>("数据类型", x => x.data_type),
            //                 new TextColumn<TableItemYC, string>("数据字节序", x => x.byte_order),
            //                 new TextColumn<TableItemYC, int>("转发分组", x => x.router_group),
            //                 new TextColumn<TableItemYC, int>("转发地址", x => x.router_addr),
            //                 new TextColumn<TableItemYC, int>("功能码", x => x.code),
            //                 new TextColumn<TableItemYC, int>("偏移地址", x => x.addr_bias),
            //             },
            //             };
            //             break;
            //         }
            //     case 3:
            //         {
            //             Source = new FlatTreeDataGridSource<TableItemYC>(TableItems)
            //             {
            //                 Columns =
            //             {
            //                 new TextColumn<TableItemYC, string>("ID3", x => x.id),
            //                 new TextColumn<TableItemYC, string>("名称", x => x.name),
            //                 new TextColumn<TableItemYC, string>("类型", x => x.val_type),
            //                 new TextColumn<TableItemYC, string>("单位", x => x.unit),
            //                 new TextColumn<TableItemYC, int>("组号", x => x.groupid),
            //                 new TextColumn<TableItemYC, int>("序号", x => x.no),
            //                 new TextColumn<TableItemYC, double>("CC1", x => x.cc1),
            //                 new TextColumn<TableItemYC, double>("Max", x => x.max),
            //                 new TextColumn<TableItemYC, double>("归零值", x => x.zero_val),
            //                 new TextColumn<TableItemYC, string>("限值方式", x => x.limit_type),
            //                 new TextColumn<TableItemYC, double>("最小限值", x => x.limit_min),
            //                 new TextColumn<TableItemYC, string>("数据类型", x => x.data_type),
            //                 new TextColumn<TableItemYC, string>("数据字节序", x => x.byte_order),
            //                 new TextColumn<TableItemYC, int>("转发分组", x => x.router_group),
            //                 new TextColumn<TableItemYC, int>("转发地址", x => x.router_addr),
            //                 new TextColumn<TableItemYC, int>("功能码", x => x.code),
            //                 new TextColumn<TableItemYC, int>("偏移地址", x => x.addr_bias),
            //             },
            //             };
            //             break;
            //         }
            //     case 4:
            //         {
            //             Source = new FlatTreeDataGridSource<TableItemYC>(TableItems)
            //             {
            //                 Columns =
            //             {
            //                 new TextColumn<TableItemYC, string>("ID4", x => x.id),
            //                 new TextColumn<TableItemYC, string>("名称", x => x.name),
            //                 new TextColumn<TableItemYC, string>("类型", x => x.val_type),
            //                 new TextColumn<TableItemYC, string>("单位", x => x.unit),
            //                 new TextColumn<TableItemYC, int>("组号", x => x.groupid),
            //                 new TextColumn<TableItemYC, int>("序号", x => x.no),
            //                 new TextColumn<TableItemYC, double>("CC1", x => x.cc1),
            //                 new TextColumn<TableItemYC, double>("Max", x => x.max),
            //                 new TextColumn<TableItemYC, double>("归零值", x => x.zero_val),
            //                 new TextColumn<TableItemYC, string>("限值方式", x => x.limit_type),
            //                 new TextColumn<TableItemYC, double>("最小限值", x => x.limit_min),
            //                 new TextColumn<TableItemYC, string>("数据类型", x => x.data_type),
            //                 new TextColumn<TableItemYC, string>("数据字节序", x => x.byte_order),
            //                 new TextColumn<TableItemYC, int>("转发分组", x => x.router_group),
            //                 new TextColumn<TableItemYC, int>("转发地址", x => x.router_addr),
            //                 new TextColumn<TableItemYC, int>("功能码", x => x.code),
            //                 new TextColumn<TableItemYC, int>("偏移地址", x => x.addr_bias),
            //             },
            //             };
            //             break;
            //         }
            // }
            //tabitems = new ObservableCollection<TabItem>()
            //{
            //    new TabItem { Header = "遥测", Content = "One's content" },
            //    new TabItem { Header = "遥信", Content = "Two's content" },
            //    new TabItem { Header = "遥脉", Content = "Two's content" },
            //    new TabItem { Header = "遥控", Content = "Two's content" },
            //    new TabItem { Header = "遥调", Content = "Two's content" },
            //};
        }

    }

}