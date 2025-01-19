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
                // ��� ViewModel Ϊ�գ���� DataContext ��ȡ��
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
            contextMenu.Items.Add("����");
            contextMenu.Items.Add("ճ��");
            contextMenu.Items.Add("ɾ��");

        }

        private async void OnNewProject(object sender, RoutedEventArgs args)
        {

        }

        private async void OnOpenFile(object sender, RoutedEventArgs args)
        {
            // �ӵ�ǰ�ؼ���ȡ TopLevel�����ߣ���Ҳ����ʹ�� Window ���á�
            var topLevel = TopLevel.GetTopLevel(this);

            // �����첽�����Դ򿪶Ի���
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open ini File",
                AllowMultiple = false
            });

            if (files.Count >= 1)
            {
                ViewModel.PrjCfgFile = files[0];
                //// �򿪵�һ���ļ��Ķ�ȡ����
                //await using var stream = await files[0].OpenReadAsync();
                //using var streamReader = new StreamReader(stream);
                //// ���ļ�������������Ϊ�ı���ȡ��
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
            ViewModel.DialogViewInfoText = "����ͨѶ��������ù������\nRouterCM V1.0.0 2018-2025(C) Govlan";
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
                                new TextColumn<TableItem, string>("����", x => x.args["Name"]),
                                new TextColumn<TableItem, string>("����", x => x.args["Type"]),
                                new TextColumn<TableItem, string>("��λ",x => x.args["Unit"]),
                                new TextColumn<TableItem, string>("���",x => x.args["GroupNum"]),
                                new TextColumn<TableItem, string>("���",x => x.args["Order"]),
                                new TextColumn<TableItem, string>("CC1", x => x.args["CC1"]),
                                new TextColumn<TableItem, string>("Max", x => x.args["Max"]),
                                new TextColumn<TableItem, string>("����ֵ", x => x.args["ZeroVal"]),
                                new TextColumn<TableItem, string>("��ֵ��ʽ",x => x.args["LimitType"]),
                                new TextColumn<TableItem, string>("��С��ֵ",x => x.args["LimitMin"]),
                                new TextColumn<TableItem, string>("��������",x => x.args["DataType"]),
                                new TextColumn<TableItem, string>("�����ֽ���", x => x.args["ByteOrder"]),
                                new TextColumn<TableItem, string>("ת������", x => x.args["TransGroup"]),
                                new TextColumn<TableItem, string>("ת����ַ", x => x.args["TransAddr"]),
                                new TextColumn<TableItem, string>("������", x => x.args["Code"]),
                                new TextColumn<TableItem, string>("ƫ�Ƶ�ַ", x => x.args["AddrBias"]),
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
                                new TextColumn<TableItem, string>("����", x => x.args["Name"]),
                                new TextColumn<TableItem, string>("���",x => x.args["GroupNum"]),
                                new TextColumn<TableItem, string>("���",x => x.args["Order"]),
                                new TextColumn<TableItem, string>("��������",x => x.args["DataType"]),
                                new TextColumn<TableItem, string>("��Լ��ַ",x => x.args["ProtocalAddr"]),
                                new TextColumn<TableItem, string>("ת������", x => x.args["TransGroup"]),
                                new TextColumn<TableItem, string>("ת����ַ", x => x.args["TransAddr"]),
                                new TextColumn<TableItem, string>("������", x => x.args["Code"]),
                                new TextColumn<TableItem, string>("ƫ�Ƶ�ַ", x => x.args["AddrBias"]),
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
                                new TextColumn<TableItem, string>("����", x => x.args["Name"]),
                                new TextColumn<TableItem, string>("����", x => x.args["Type"]),
                                new TextColumn<TableItem, string>("��λ",x => x.args["Unit"]),
                                new TextColumn<TableItem, string>("���",x => x.args["GroupNum"]),
                                new TextColumn<TableItem, string>("���",x => x.args["Order"]),
                                new TextColumn<TableItem, string>("CC1", x => x.args["CC1"]),
                                new TextColumn<TableItem, string>("Max", x => x.args["Max"]),
                                new TextColumn<TableItem, string>("����ֵ", x => x.args["ZeroVal"]),
                                new TextColumn<TableItem, string>("��ֵ��ʽ",x => x.args["LimitType"]),
                                new TextColumn<TableItem, string>("��С��ֵ",x => x.args["LimitMin"]),
                                new TextColumn<TableItem, string>("��������",x => x.args["DataType"]),
                                new TextColumn<TableItem, string>("�����ֽ���", x => x.args["ByteOrder"]),
                                new TextColumn<TableItem, string>("ת������", x => x.args["TransGroup"]),
                                new TextColumn<TableItem, string>("ת����ַ", x => x.args["TransAddr"]),
                                new TextColumn<TableItem, string>("������", x => x.args["Code"]),
                                new TextColumn<TableItem, string>("ƫ�Ƶ�ַ", x => x.args["AddrBias"]),
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
                                new TextColumn<TableItem, string>("����", x => x.args["Name"]),
                                new TextColumn<TableItem, string>("���",x => x.args["Order"]),
                                new TextColumn<TableItem, string>("������", x => x.args["Code"]),
                                new TextColumn<TableItem, string>("��������",x => x.args["DataType"]),
                                new TextColumn<TableItem, string>("�Ĵ�����ַ",x => x.args["AddrReg"]),
                                new TextColumn<TableItem, string>("ƫ�Ƶ�ַ", x => x.args["AddrBias"]),
                                new TextColumn<TableItem, string>("д��ONֵ", x => x.args["OnVal"]),
                                new TextColumn<TableItem, string>("д��OFFֵ", x => x.args["OffVal"]),
                                new TextColumn<TableItem, string>("ת������", x => x.args["TransGroup"]),
                                new TextColumn<TableItem, string>("ת����ַ", x => x.args["TransAddr"]),
                                new TextColumn<TableItem, string>("ң�ر���", x => x.args["MsgYK"]),
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
                                new TextColumn<TableItem, string>("����", x => x.args["Name"]),
                                new TextColumn<TableItem, string>("���",x => x.args["GroupNum"]),
                                new TextColumn<TableItem, string>("���",x => x.args["Order"]),
                                new TextColumn<TableItem, string>("CC1", x => x.args["CC1"]),
                                new TextColumn<TableItem, string>("Max", x => x.args["Max"]),
                                new TextColumn<TableItem, string>("��������",x => x.args["DataType"]),
                                new TextColumn<TableItem, string>("��Լ��ַ",x => x.args["ProtocalAddr"]),
                                new TextColumn<TableItem, string>("�����ֽ���", x => x.args["ByteOrder"]),
                                new TextColumn<TableItem, string>("ת������", x => x.args["TransGroup"]),
                                new TextColumn<TableItem, string>("ת����ַ", x => x.args["TransAddr"]),
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
            // �������¼�
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