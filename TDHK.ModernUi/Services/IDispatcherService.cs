using System;
using System.Windows.Threading;

namespace TDHK.ModernUi.Services;

public interface IDispatcherService
{
    void RunOnMainThread(Action action);
    void RunOnUIThread(DispatcherObject d, Action action);
}