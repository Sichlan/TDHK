using System;
using System.Windows;
using System.Windows.Threading;
using TDHK.Common.Services;

namespace TDHK.ModernUi.Services
{
    public class DispatcherService : IDispatcherService
    {
        public void RunOnMainThread(Action action)
        {
            RunOnUIThread(Application.Current, action);
        }

        private static void RunOnUIThread(DispatcherObject d, Action action)
        {
            var dispatcher = d.Dispatcher;

            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.BeginInvoke(action);
            }
        }
    }
}