using System.Windows;
using PulseAPK.Core.Abstractions;

namespace PulseAPK.Services;

public class WpfDispatcherService : IDispatcherService
{
    public Task InvokeAsync(Action action)
    {
        if (Application.Current?.Dispatcher == null) return Task.CompletedTask;
        return Application.Current.Dispatcher.InvokeAsync(action).Task;
    }

    public Task<T> InvokeAsync<T>(Func<T> func)
    {
        if (Application.Current?.Dispatcher == null) return Task.FromResult(default(T)!);
        return Application.Current.Dispatcher.InvokeAsync(func).Task;
    }

    public bool CheckAccess()
    {
        return Application.Current?.Dispatcher?.CheckAccess() ?? true;
    }
}
