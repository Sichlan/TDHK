using System.Windows;

namespace TDHK.ModernUi.Views.Users;

public partial class UserMessageView
{
    public UserMessageView()
    {
        InitializeComponent();
    }

    private void ButtonDetailsOnClick(object sender, RoutedEventArgs e)
    {
        if (TextMessageDetails.Visibility == Visibility.Collapsed)
            TextMessageDetails.Visibility = Visibility.Visible;
        else
            TextMessageDetails.Visibility = Visibility.Collapsed;
    }
}