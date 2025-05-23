﻿using System.Collections.ObjectModel;
using System.Diagnostics;
using TDHK.Common.ViewModels.Users;

namespace TDHK.Common.Services.UserInformationService;

/// <inheritdoc/>
public class ViewModelUserInformationMessageService : IUserInformationMessageService
{
    private readonly CreateUserMessageViewModel _createUserMessageViewModel;
    private readonly CancellationTokenSource _cancellationTokenSource;
    private readonly IDispatcherService _dispatcherService;
    private Task _updateTask = Task.CompletedTask;

    public ObservableCollection<UserMessageViewModel> UserMessageViewModels { get; } = new();

    public ViewModelUserInformationMessageService(CreateUserMessageViewModel createUserMessageViewModel, IDispatcherService dispatcherService)
    {
        _createUserMessageViewModel = createUserMessageViewModel;
        _dispatcherService = dispatcherService;
        _cancellationTokenSource = new CancellationTokenSource();

        QueueTask(ExecuteUpdateTaskLoop);
    }

    private async Task ExecuteUpdateTaskLoop()
    {
        await Task.Delay(100);

        // Debug.WriteLine("Running Update Loop");

        foreach (var userMessageViewModel in UserMessageViewModels)
        {
            if (userMessageViewModel.TimeRemaining <= 0 && !userMessageViewModel.IsPaused)
                RemoveDisplayMessage(userMessageViewModel);
            else
                userMessageViewModel.AdvanceTimeIfNotPaused();
        }

        if (!_cancellationTokenSource.IsCancellationRequested)
            QueueTask(ExecuteUpdateTaskLoop);
    }

    private void QueueTask(Func<Task> nextTask)
    {
        _updateTask = _updateTask.ContinueWith(_ => nextTask()).Unwrap();
    }

    ~ViewModelUserInformationMessageService()
    {
        _cancellationTokenSource.Cancel();
    }

    /// <inheritdoc/>
    public void AddDisplayMessage(string message, InformationType type, int? deleteAfter = null, string messageDetails = "")
    {
        QueueTask(() => Task.Run(() =>
        {
            Debug.WriteLine(
                $"[{type.ToString()[..3].ToUpper()}]: {message} " +
                $"{(deleteAfter > 0 ? $"({deleteAfter} sec.)" : "")}" +
                $"{(!string.IsNullOrEmpty(messageDetails) ? $"\n - {messageDetails}" : "")}");

            _dispatcherService.RunOnMainThread(() => UserMessageViewModels.Add(_createUserMessageViewModel(message, type, deleteAfter, messageDetails)));
        }));
    }

    /// <inheritdoc/>
    public void AddDisplayMessage(string message, InformationType type, TimeSpan deleteAfter, string messageDetails = "")
    {
        AddDisplayMessage(message, type, (int)deleteAfter.TotalMilliseconds, messageDetails);
    }

    /// <inheritdoc/>
    public void RemoveDisplayMessage(UserMessageViewModel message)
    {
        QueueTask(() => Task.Run(() =>
        {
            _dispatcherService.RunOnMainThread(() => UserMessageViewModels.Remove(message));
        }));
    }
}