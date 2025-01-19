using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using RouterCM.ViewModels;
using Avalonia.Controls.Models.TreeDataGrid;
using Avalonia.Controls.Primitives;
using Avalonia.Platform.Storage;
using System.IO;
using Avalonia.Controls.Selection;
using Avalonia.Media;
using DialogHostAvalonia;

namespace RouterCM.Views
{
    public partial class MainWindow : Window
    {
        private TabControl tabControl { get; set; }

        private MainWindowViewModel _ViewModel { get; set; }
        private MainWindowViewModel ViewModel
        {
            get
            {
                // 如果 ViewModel 为空，则从 DataContext 获取。
                if (_ViewModel == null)
                {
                    _ViewModel = DataContext as MainWindowViewModel ?? throw new InvalidOperationException("DataContext is not of type MainWindowViewModel.");
                }
                return _ViewModel ?? throw new InvalidOperationException("ViewModel is not initialized.");
            }
            set { ; }
        }


        public MainWindow()
        {
            InitializeComponent();

            ContextMenu contextMenu = new ContextMenu();
            contextMenu.Items.Add("复制");
            contextMenu.Items.Add("粘贴");
            contextMenu.Items.Add("删除");

        }

        private async void OnNewProject(object sender, RoutedEventArgs args)
        {

        }

        private async void OnOpenFile(object sender, RoutedEventArgs args)
        {
            // 从当前控件获取 TopLevel。或者，您也可以使用 Window 引用。
            var topLevel = TopLevel.GetTopLevel(this);

            // 启动异步操作以打开对话框。
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open ini File",
                AllowMultiple = false
            });

            if (files.Count >= 1)
            {
                ViewModel.PrjCfgFile = files[0];
                //// 打开第一个文件的读取流。
                //await using var stream = await files[0].OpenReadAsync();
                //using var streamReader = new StreamReader(stream);
                //// 将文件的所有内容作为文本读取。
                //var fileContent = await streamReader.ReadToEndAsync();
            }
        }



        private async void OnSaveFile(object sender, RoutedEventArgs args)
        {

        }

        private async void OnOpenProtocolTemp(object sender, RoutedEventArgs args)
        {

        }

        private async void OnOpendevTemp(object sender, RoutedEventArgs args)
        {

        }

        private async void OnCommSet(object sender, RoutedEventArgs args)
        {

        }

        private async void OnMonitor(object sender, RoutedEventArgs args)
        {

        }

        private async void OnManageFile(object sender, RoutedEventArgs args)
        {

        }

        private async void OnReboot(object sender, RoutedEventArgs args)
        {

        }

        private async void OnOpenPutty(object sender, RoutedEventArgs args)
        {

        }

        private async void OnOpenFtp(object sender, RoutedEventArgs args)
        {

        }

        private async void OnOpenTutorial(object sender, RoutedEventArgs args)
        {

        }

        private async void OnAbout(object sender, RoutedEventArgs args)
        {
            ViewModel.DialogViewInfoText = "智能通讯管理机配置管理软件\nRouterCM V1.0.0 2018-2025(C) Govlan";
            await DialogHost.Show(Resources["DialogViewInfoWithPic"]!, "MainDialogHost");
        }

        private void TabCtrlSelectChanged(object sender, SelectionChangedEventArgs e)
        {
            TabStrip? tabcontrol = this.FindControl<TabStrip>("TabDataCatChoose");
            ViewModel.TableTitle = ((DataCategory)tabcontrol!.SelectedIndex).ToString();
            ViewModel.Info = ((DataCategory)tabcontrol!.SelectedIndex).ToString();
            TextColumnOptions<TableItem> options = new TextColumnOptions<TableItem>()
            {
                // TextWrapping = TextWrapping.Wrap,
                // TextAlignment = TextAlignment.Left,
                BeginEditGestures = BeginEditGestures.DoubleTap
            };
            switch ((DataCategory)tabcontrol.SelectedIndex)
            {
                case DataCategory.YC:
                    {
                        ViewModel.Source = new FlatTreeDataGridSource<TableItem>(new ObservableCollection<TableItem>() { new TableItem(), new TableItem() })
                        {

                            Columns = {
                                new TextColumn<TableItem, int>("ID", x => x.id,(r, v) => r.id = v,options: options , width:GridLength.Auto),
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
                            }
                        };
                        break;
                    }
                case DataCategory.YX:
                    {

                        ViewModel.Source = new FlatTreeDataGridSource<TableItem>(new ObservableCollection<TableItem>() { new TableItem() })
                        {
                            Columns =
                            {
                                new TextColumn<TableItem, int>("ID", x => x.id),
                                new TextColumn<TableItem, string>("名称", x => x.args["Name"]),
                                new TextColumn<TableItem, string>("组号",x => x.args["GroupNum"]),
                                new TextColumn<TableItem, string>("序号",x => x.args["Order"]),
                                new TextColumn<TableItem, string>("数据类型",x => x.args["DataType"]),
                                new TextColumn<TableItem, string>("规约地址",x => x.args["ProtocalAddr"]),
                                new TextColumn<TableItem, string>("转发分组", x => x.args["TransGroup"]),
                                new TextColumn<TableItem, string>("转发地址", x => x.args["TransAddr"]),
                                new TextColumn<TableItem, string>("功能码", x => x.args["Code"]),
                                new TextColumn<TableItem, string>("偏移地址", x => x.args["AddrBias"]),
                            }
                        };
                        break;
                    }
                case DataCategory.YM:
                    {

                        ViewModel.Source = new FlatTreeDataGridSource<TableItem>(new ObservableCollection<TableItem>() { new TableItem() })
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
                            }
                        };
                        break;
                    }
                case DataCategory.YK:
                    {

                        ViewModel.Source = new FlatTreeDataGridSource<TableItem>(new ObservableCollection<TableItem>() { new TableItem() })
                        {
                            Columns =
                            {
                                new TextColumn<TableItem, int>("ID", x => x.id),
                                new TextColumn<TableItem, string>("名称", x => x.args["Name"]),
                                new TextColumn<TableItem, string>("序号",x => x.args["Order"]),
                                new TextColumn<TableItem, string>("功能码", x => x.args["Code"]),
                                new TextColumn<TableItem, string>("数据类型",x => x.args["DataType"]),
                                new TextColumn<TableItem, string>("寄存器地址",x => x.args["AddrReg"]),
                                new TextColumn<TableItem, string>("偏移地址", x => x.args["AddrBias"]),
                                new TextColumn<TableItem, string>("写入ON值", x => x.args["OnVal"]),
                                new TextColumn<TableItem, string>("写入OFF值", x => x.args["OffVal"]),
                                new TextColumn<TableItem, string>("转发分组", x => x.args["TransGroup"]),
                                new TextColumn<TableItem, string>("转发地址", x => x.args["TransAddr"]),
                                new TextColumn<TableItem, string>("遥控报文", x => x.args["MsgYK"]),
                            }
                        };
                        break;
                    }
                case DataCategory.YT:
                    {

                        ViewModel.Source = new FlatTreeDataGridSource<TableItem>(new ObservableCollection<TableItem>() { new TableItem() })
                        {
                            Columns =
                            {
                                new TextColumn<TableItem, int>("ID", x => x.id),
                                new TextColumn<TableItem, string>("名称", x => x.args["Name"]),
                                new TextColumn<TableItem, string>("组号",x => x.args["GroupNum"]),
                                new TextColumn<TableItem, string>("序号",x => x.args["Order"]),
                                new TextColumn<TableItem, string>("CC1", x => x.args["CC1"]),
                                new TextColumn<TableItem, string>("Max", x => x.args["Max"]),
                                new TextColumn<TableItem, string>("数据类型",x => x.args["DataType"]),
                                new TextColumn<TableItem, string>("规约地址",x => x.args["ProtocalAddr"]),
                                new TextColumn<TableItem, string>("数据字节序", x => x.args["ByteOrder"]),
                                new TextColumn<TableItem, string>("转发分组", x => x.args["TransGroup"]),
                                new TextColumn<TableItem, string>("转发地址", x => x.args["TransAddr"]),
                            }
                        };
                        break;
                    }
                default:
                    return;
            }
            ViewModel.Source.Selection = new TreeDataGridCellSelectionModel<TableItem>(ViewModel.Source);
        }

        public void myTextBlock_Tap(object sender, RoutedEventArgs e)
        {
            TreeViewItem item;
            var control = e.Source as Control;
            // 处理点击事件
            MessageBoxManager.GetMessageBoxStandard("Caption", $"name: {control.Name}, type: {control.GetType()}",
           ButtonEnum.Ok).ShowWindowDialogAsync(this);
        }

        private async void OpenNoAnimationDialog(object? sender, RoutedEventArgs e)
        {
            ViewModel.DialogViewInfoText = "No animation dialog";
            await DialogHost.Show(Resources["Sample2View"]!, "NoAnimationDialogHost");
        }

    }
}