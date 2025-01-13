using System;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia;
using RouterCM.ViewModels;
using Avalonia.Controls.Models.TreeDataGrid;

namespace RouterCM.Views
{
    public partial class MainWindow : Window
    {

        private MainWindowViewModel viewModel { get; set; }
        private TabControl tabControl;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainWindowViewModel();

            //tabControl = this.FindControl<TabControl>("tabcontrol");
            //tabControl.SelectionChanged += _parentTabControl_SelectionChanged; // here is the subscription point
            //viewModel.TableTitle = "123";
        }


        public async void _parentTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControl tabcontrol = this.FindControl<TabControl>("tabcontrol");
            viewModel.TableTitle = tabcontrol.SelectedIndex.ToString();
            if (this.IsVisible)
                MessageBoxManager.GetMessageBoxStandard("Caption", $"viewModel.TableTitle = {viewModel.TableTitle}",
           ButtonEnum.Ok).ShowWindowDialogAsync(this);
            switch (tabcontrol.SelectedIndex)
            {
                case 0:
                    {
                        viewModel.Source = new FlatTreeDataGridSource<TableItemYC>(viewModel.TableItems)
                        {
                            Columns =
                        {
                            new TextColumn<TableItemYC, string>("ID0", x => x.id),
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
                        break;
                    }

                case 1:
                    {
                        viewModel.Source.Columns.Clear();
                        //     viewModel.Source = new FlatTreeDataGridSource<TableItemYC>(viewModel.TableItems)
                        //     {
                        //         Columns =
                        //     {
                        //         new TextColumn<TableItemYC, string>("ID1", x => x.id),
                        //         new TextColumn<TableItemYC, string>("名称", x => x.name),
                        //         new TextColumn<TableItemYC, string>("类型", x => x.val_type),
                        //         new TextColumn<TableItemYC, string>("单位", x => x.unit),
                        //         new TextColumn<TableItemYC, int>("组号", x => x.groupid),
                        //         new TextColumn<TableItemYC, int>("序号", x => x.no),
                        //         new TextColumn<TableItemYC, double>("CC1", x => x.cc1),
                        //         new TextColumn<TableItemYC, double>("Max", x => x.max),
                        //         new TextColumn<TableItemYC, double>("归零值", x => x.zero_val),
                        //         new TextColumn<TableItemYC, string>("限值方式", x => x.limit_type),
                        //         new TextColumn<TableItemYC, double>("最小限值", x => x.limit_min),
                        //         new TextColumn<TableItemYC, string>("数据类型", x => x.data_type),
                        //         new TextColumn<TableItemYC, string>("数据字节序", x => x.byte_order),
                        //         new TextColumn<TableItemYC, int>("转发分组", x => x.router_group),
                        //         new TextColumn<TableItemYC, int>("转发地址", x => x.router_addr),
                        //         new TextColumn<TableItemYC, int>("功能码", x => x.code),
                        //         new TextColumn<TableItemYC, int>("偏移地址", x => x.addr_bias),
                        //     },
                        //     };
                        //     MessageBoxManager.GetMessageBoxStandard("Caption", $"current sleect: {tabcontrol.SelectedIndex}",
                        //ButtonEnum.Ok).ShowWindowDialogAsync(this);
                        break;
                    }
                case 2:
                    {
                        viewModel.Source = new FlatTreeDataGridSource<TableItemYC>(viewModel.TableItems)
                        {
                            Columns =
                        {
                            new TextColumn<TableItemYC, string>("ID2", x => x.id),
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
                        break;
                    }
                case 3:
                    {
                        viewModel.Source = new FlatTreeDataGridSource<TableItemYC>(viewModel.TableItems)
                        {
                            Columns =
                        {
                            new TextColumn<TableItemYC, string>("ID3", x => x.id),
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
                        break;
                    }
                case 4:
                    {
                        viewModel.Source = new FlatTreeDataGridSource<TableItemYC>(viewModel.TableItems)
                        {
                            Columns =
                        {
                            new TextColumn<TableItemYC, string>("ID4", x => x.id),
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
                        break;
                    }
            }
            //viewModel.tabitems = new ObservableCollection<TabItem>()
            //{
            //    new TabItem { Header = "遥测", Content = "One's content" },
            //    new TabItem { Header = "遥信", Content = "Two's content" },
            //    new TabItem { Header = "遥脉", Content = "Two's content" },
            //    new TabItem { Header = "遥控", Content = "Two's content" },
            //    new TabItem { Header = "遥调", Content = "Two's content" },
            //};
        }

        private void Binding(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
        }
    }
}