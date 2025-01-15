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
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] private string? _TableTitle;
        //public string? TableTitle { get { return _TableTitle; } set { this.RaiseAndSetIfChanged(ref _TableTitle, value); } }
        public ObservableCollection<TabItem> TableTabItems { get; set; }
        public ObservableCollection<TabItem> NavTabiIems { get; set; }

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

            project_explorer = new ProjectExplorer("项目组", new ObservableCollection<ProjectGroup>{
                    new ProjectGroup("测试", new ObservableCollection<Project>{
                      new Project("安岳箱变", new ObservableCollection<ComManager>{
                          new ComManager("ANet-2E4S1[00037686090068]", new ObservableCollection<Module>{
                            new Module("主模块", new ObservableCollection<Port>{
                                new Port("串口1", new ObservableCollection<Dev>{
                                    new Dev("多功能仪表（PM）[HZ194E-9SY]"),
                                    new Dev("多功能仪表（5PM）[HZ194E-9SY]"),
                                    new Dev("多功能仪表（6PM）[HZ194E-9SY]"),
                                    new Dev("多功能仪表（7PM）[HZ194E-9SY]"),
                                }),
                                new Port("串口2", new ObservableCollection<Dev>{
                                    new Dev("相变温湿度传感器[DL-XB3W1S]"),
                                }),
                                new Port("串口3", new ObservableCollection<Dev>{
                                    new Dev("遥信单元1[222]"),
                                    new Dev("遥信单元2[222]"),
                                }),
                                new Port("串口4", new ObservableCollection<Dev>{
                                    new Dev("干变温控器[YK-BWDK130C]"),
                                }),
                            }),
                          }),
                      }),
                    }),
                });

            Source = new FlatTreeDataGridSource<TableItem>(new ObservableCollection<TableItem>() { new TableItem() })
            {
                Columns =
                {
                    new TextColumn<TableItem, int>("ID", x => x.id),
                    new TextColumn<TableItem, string>("名称", x => x.args["Name"]),
                    new TextColumn<TableItem, string>("类型", x => x.args["Type"]),
                    new TextColumn<TableItem, string>("单位",x => x.args["Unit"]),
                    new TextColumn<TableItem, string>("组号",x => x.args["GroupNum"]),
                    new TextColumn<TableItem, string>("序号",x => x.args["Order"]),
                    new TextColumn<TableItem, string>("CC1", x => x.args["CC1"]),
                    new TextColumn<TableItem, string>("Max", x => x.args["Max"]),
                    new TextColumn<TableItem, string>("归零值", x => x.args["ZeroVal"]),
                    new TextColumn<TableItem, string>("限值方式",x => x.args["LimitType"]),
                    new TextColumn<TableItem, string>("最小限值",x => x.args["LimitMin"]),
                    new TextColumn<TableItem, string>("数据类型",x => x.args["DataType"]),
                    new TextColumn<TableItem, string>("数据字节序", x => x.args["ByteOrder"]),
                    new TextColumn<TableItem, string>("转发分组", x => x.args["TransGroup"]),
                    new TextColumn<TableItem, string>("转发地址", x => x.args["TransAddr"]),
                    new TextColumn<TableItem, string>("功能码", x => x.args["Code"]),
                    new TextColumn<TableItem, string>("偏移地址", x => x.args["AddrBias"]),
                },
            };

            TableTabItems = new ObservableCollection<TabItem>()
            {
                new TabItem { Header = "遥测" },
                new TabItem { Header = "遥信" },
                new TabItem { Header = "遥脉" },
                new TabItem { Header = "遥控" },
                new TabItem { Header = "遥调" }
            };

            NavTabiIems = new ObservableCollection<TabItem>()
            {
                new TabItem { Header = "项目配置" },
                new TabItem { Header = "转发方案" },
                new TabItem { Header = "实时监控" },
            };
        }

        public ProjectExplorer project_explorer { get; }

        [ObservableProperty] private FlatTreeDataGridSource<TableItem>? _Source;


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

        public void myTextBlock_Tap(object sender, RoutedEventArgs e)
        {
            // 处理点击事件

        }

    }

}