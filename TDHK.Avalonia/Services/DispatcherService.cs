using System;
using Avalonia.Threading;
using TDHK.Common.Services;

namespace TDHK.Avalonia.Services;

public class DispatcherService : IDispatcherService
{
    public void RunOnMainThread(Action action)
    {
        var dispatcher = Dispatcher.UIThread;

        if (dispatcher.CheckAccess())
            action();
        else
            dispatcher.Invoke(action);
    }
}