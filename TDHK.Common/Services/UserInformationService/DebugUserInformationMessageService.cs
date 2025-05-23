﻿using System.Collections.ObjectModel;
using System.Diagnostics;
using TDHK.Common.ViewModels.Users;

namespace TDHK.Common.Services.UserInformationService;

/// <inheritdoc/>
// Used for debug purposes, otherwise not used.
// ReSharper disable once UnusedType.Global
public class DebugUserInformationMessageService : IUserInformationMessageService
{
    public ObservableCollection<UserMessageViewModel> UserMessageViewModels { get; } = new();

    /// <inheritdoc/>
    public void AddDisplayMessage(string message, InformationType type, int? deleteAfter = null, string messageDetails = "")
    {
        Debug.WriteLine(
            $"[{type.ToString()[..3].ToUpper()}]: {message} " +
            $"{(deleteAfter > 0 ? $"({deleteAfter} sec.)" : "")}" +
            $"{(!string.IsNullOrEmpty(messageDetails) ? $"\n - {messageDetails}" : "")}");
    }

    /// <inheritdoc/>
    public void AddDisplayMessage(string message, InformationType type, TimeSpan deleteAfter, string messageDetails = "")
    {
        AddDisplayMessage(message, type, deleteAfter.Milliseconds, messageDetails);
    }

    /// <inheritdoc/>
    /// This method does nothing because this service does not have a functioning message queue.
    public void RemoveDisplayMessage(UserMessageViewModel message)
    { }
}