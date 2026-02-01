using Avalonia.Threading;
using PulseAPK.Core.Abstractions;
using System;
using System.Threading.Tasks;

namespace PulseAPK.Avalonia.Services;

public class AvaloniaDispatcherService : IDispatcherService
{
    public Task InvokeAsync(Action action)
    {
        return Dispatcher.UIThread.InvokeAsync(action).GetTask();
    }

    public Task<T> InvokeAsync<T>(Func<T> func)
    {
        return Dispatcher.UIThread.InvokeAsync(func).GetTask();
    }

    public bool CheckAccess()
    {
        return Dispatcher.UIThread.CheckAccess();
    }
}
