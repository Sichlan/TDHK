using System.Collections.ObjectModel;
using TDHK.Common.ViewModels.Users;

namespace TDHK.Common.Services.UserInformationService;

public enum InformationType
{
    Information,
    Success,
    Warning,
    Error
}

/// <summary>
/// Defines methods for displaying messages to the user. 
/// </summary>
public interface IUserInformationMessageService
{
    ObservableCollection<UserMessageViewModel> UserMessageViewModels { get; }

    /// <summary>
    /// Displays a message to the user, using a style appropriate to the message type.
    /// </summary>
    /// <param name="message">The message the user should instantly see.</param>
    /// <param name="type">The appropriate type for this message.</param>
    /// <param name="deleteAfter">If set and bigger than 0, the message will disappear from UI in this amount of milliseconds.</param>
    /// <param name="messageDetails">If the message contains more content than appropriate for a header, set it here.</param>
    public void AddDisplayMessage(string message, InformationType type, int? deleteAfter = null, string messageDetails = "");

    /// <summary>
    /// Displays a message to the user, using a style appropriate to the message type.
    /// </summary>
    /// <param name="message">The message the user should instantly see.</param>
    /// <param name="type">The appropriate type for this message.</param>
    /// <param name="deleteAfter">If set and bigger than 0, the message will disappear from UI after that timespan.</param>
    /// <param name="messageDetails">If the message contains more content than appropriate for a header, set it here.</param>
    public void AddDisplayMessage(string message, InformationType type, TimeSpan deleteAfter, string messageDetails = "");

    /// <summary>
    /// Removes a message manually from the collection.
    /// </summary>
    /// <param name="message">The message that should be removed.</param>
    public void RemoveDisplayMessage(UserMessageViewModel message);
}