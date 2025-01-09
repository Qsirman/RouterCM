using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using RouterCM.ViewModels;

namespace RouterCM.Views
{
    public partial class MainWindow : Window
    {

        private readonly MainWindowViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            viewModel = new MainWindowViewModel();
        }

        void OnMainMenuOpened(object sender, RoutedEventArgs args)
        {
            //viewModel.RefreshOpenRecent();
            //viewModel.RefreshTemplates();
            //viewModel.RefreshCacheSize();
        }

        void OnMainMenuClosed(object sender, RoutedEventArgs args)
        {
            Focus(); // Force unfocus menu for key down events.
        }

        void OnMainMenuPointerLeave(object sender, PointerEventArgs args)
        {
            Focus(); // Force unfocus menu for key down events.
        }

        void OnMenuNew(object sender, RoutedEventArgs args) => NewProject();
        async void NewProject()
        {
            //if (!DocManager.Inst.ChangesSaved && !await AskIfSaveAndContinue())
            //{
            //    return;
            //}
            //viewModel.NewProject();
        }
    }
}