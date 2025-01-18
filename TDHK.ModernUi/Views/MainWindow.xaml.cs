using System.Windows;
using System.Windows.Controls;
using TDHK.ModernUi.Models;
using TDHK.ModernUi.ViewModels;

namespace TDHK.ModernUi.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private int _spellcardTabIndex = 0;

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

        private void SpellCardTabControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is not TabControl tabControl || e.AddedItems.Count < 1)
                return;

            if (e.AddedItems[0] is not SpellCard)
                tabControl.SelectedIndex = _spellcardTabIndex;
            else
                _spellcardTabIndex = tabControl.SelectedIndex;
        }
    }
}