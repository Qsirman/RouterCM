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
using Avalonia.Controls.Primitives;
using Avalonia.Platform.Storage;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Controls.Selection;
using Avalonia.Media;
using DialogHostAvalonia;
using System.Net.NetworkInformation;

namespace RouterCM.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] private string? _TableTitle;
        [ObservableProperty] private string? _DialogViewInfoText;
        [ObservableProperty] private string? _Status;
        [ObservableProperty] private string? _TimeStr;
        [ObservableProperty] private string? _Info;
        public ProjectExplorer project_explorer { get; }

        [ObservableProperty] private FlatTreeDataGridSource<TableItem>? _Source;
        private ExplorerItem _ExplorerItemSelected;
        public ExplorerItem ExplorerItemSelected
        {
            get { return _ExplorerItemSelected; }
            set
            {
                if (_ExplorerItemSelected == value)
                    return;
                _ExplorerItemSelected = value;
                TableTitle = $"Name: {_ExplorerItemSelected.Name} Type: {_ExplorerItemSelected.Type}";
                // Do logic on selection change.
            }
        }
        private IStorageFile? _PrjCfgFile;
        public IStorageFile? PrjCfgFile
        {
            get // IStorageFile a = PrjCfgFile;
            {
                return _PrjCfgFile;
            }
            set// IStorageFile a; PrjCfgFile = a;
            {
                _PrjCfgFile = value;
                Task.Run(LoadPrjCfgFile);
            }
        }

        public async Task LoadPrjCfgFile()
        {
            if (_PrjCfgFile == null)
            {
                return;
            }
            await using var stream = await _PrjCfgFile.OpenReadAsync();
            using var streamReader = new StreamReader(stream);
            // 将文件的所有内容作为文本读取。
            var fileContent = await streamReader.ReadToEndAsync();
            TableTitle = fileContent.ToString();
        }


        public ObservableCollection<TabStripItem> TableTabItems { get; set; }
        public ObservableCollection<TabStripItem> NavTabiIems { get; set; }

        public MainWindowViewModel()
        {
            _Status = "Ready";
            TimeStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            project_explorer = new ProjectExplorer("项目组", new ObservableCollection<ExplorerItem>{
                    new ExplorerItem("测试", new ObservableCollection<ExplorerItem>{
                      new ExplorerItem("安岳箱变", new ObservableCollection<ExplorerItem>{
                          new ExplorerItem("ANet-2E4S1[00037686090068]", new ObservableCollection<ExplorerItem>{
                            new ExplorerItem("主模块", new ObservableCollection<ExplorerItem>{
                                new ExplorerItem("串口1", new ObservableCollection<ExplorerItem>{
                                    new ExplorerItem("多功能仪表（PM）[HZ194E-9SY]", ExplorerItemType.Dev),
                                    new ExplorerItem("多功能仪表（5PM）[HZ194E-9SY]", ExplorerItemType.Dev),
                                    new ExplorerItem("多功能仪表（6PM）[HZ194E-9SY]", ExplorerItemType.Dev),
                                    new ExplorerItem("多功能仪表（7PM）[HZ194E-9SY]", ExplorerItemType.Dev),
                                }, ExplorerItemType.Port),
                                new ExplorerItem("串口2", new ObservableCollection<ExplorerItem>{
                                    new ExplorerItem("相变温湿度传感器[DL-XB3W1S]", ExplorerItemType.Dev),
                                }, ExplorerItemType.Port),
                                new ExplorerItem("串口3", new ObservableCollection<ExplorerItem>{
                                    new ExplorerItem("遥信单元1[222]", ExplorerItemType.Dev),
                                    new ExplorerItem("遥信单元2[222]", ExplorerItemType.Dev),
                                }, ExplorerItemType.Port),
                                new ExplorerItem("串口4", new ObservableCollection<ExplorerItem>{
                                    new ExplorerItem("干变温控器[YK-BWDK130C]", ExplorerItemType.Dev),
                                }, ExplorerItemType.Port),
                            }, ExplorerItemType.Module),
                          }, ExplorerItemType.ComManager),
                      }, ExplorerItemType.Project),
                    }, ExplorerItemType.ProjectGroup),
                });

            Source = new FlatTreeDataGridSource<TableItem>(new ObservableCollection<TableItem>() { new TableItem() })
            {
                Columns =
                {
                    new TextColumn<TableItem, int>("ID", x => x.id,null ,new TextColumnOptions<TableItem>(){BeginEditGestures = BeginEditGestures.Tap}),
                    new TextColumn<TableItem, string>("名称", x => x.args["Name"],null,new TextColumnOptions<TableItem>(){BeginEditGestures = BeginEditGestures.Tap}),
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

            Source.RowSelection!.SingleSelect = true;

            Source.Selection = new TreeDataGridCellSelectionModel<TableItem>(Source);

            TableTabItems = new ObservableCollection<TabStripItem>()
            {
                new TabStripItem { Content = "遥测" },
                new TabStripItem { Content = "遥信" },
                new TabStripItem { Content = "遥脉" },
                new TabStripItem { Content = "遥控" },
                new TabStripItem { Content = "遥调" }
            };

            NavTabiIems = new ObservableCollection<TabStripItem>()
            {
                new TabStripItem { Content = "项目配置" },
                new TabStripItem { Content = "转发方案" },
                new TabStripItem { Content = "实时监控" },
            };
        }
        public void myTextBlock_Tap(object sender, RoutedEventArgs e)
        {
            // 处理点击事件

        }

    }

}