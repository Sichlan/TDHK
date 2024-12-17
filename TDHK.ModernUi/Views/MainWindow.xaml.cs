using System.Windows;
using TDHK.ModernUi.ViewModels;

namespace TDHK.ModernUi.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(MainViewModel dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
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