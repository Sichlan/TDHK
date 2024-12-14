using System;
using System.Windows;
using ModernWpf.Controls;
using TDHK.ModernUi.ViewModels;

namespace TDHK.ModernUi.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly MainViewModel _mainViewModel;

        public MainWindow(MainViewModel dataContext)
        {
            InitializeComponent();

            _mainViewModel = dataContext;

            DataContext = _mainViewModel;
        }

        private Type GetPageType(NavigationViewItem item)
        {
            return item.Tag as Type;
        }

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.WidthChanged && Application.Current.TryFindResource("ContentDialogMaxWidth") != null)
            {
                Application.Current.Resources["ContentDialogMaxWidth"] = e.NewSize.Width;
            }

            if (e.WidthChanged && Application.Current.TryFindResource("ContentDialogMaxHeight") != null)
            {
                Application.Current.Resources["ContentDialogMaxHeight"] = e.NewSize.Height;
            }
        }
    }
}