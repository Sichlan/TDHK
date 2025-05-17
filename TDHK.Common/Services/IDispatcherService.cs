namespace TDHK.Common.Services;

public interface IDispatcherService
{
    void RunOnMainThread(Action action);
}