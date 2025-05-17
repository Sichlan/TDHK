using TDHK.Common.ViewModels;

namespace TDHK.Avalonia.ViewModels;

public abstract class NavigableViewModel : ViewModelBase
{
    /// <summary>
    /// The title of the view model that is automatically displayed in the UI. If the view model itself defines no title, "NOT LOCALIZED" serves both as a fallback and a reminder.
    /// </summary>
    public virtual string ViewModelTitle { get; } = "NOT LOCALIZED";

    public virtual void OnNavigateTo() { }
    public virtual void OnNavigateFrom() { }
}