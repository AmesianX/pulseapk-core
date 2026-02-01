namespace PulseAPK.Core.Abstractions;

/// <summary>
/// Platform-agnostic dispatcher service for marshalling calls to the UI thread.
/// Replaces direct usage of Application.Current.Dispatcher or similar.
/// </summary>
public interface IDispatcherService
{
    /// <summary>
    /// Invokes an action on the UI thread.
    /// </summary>
    Task InvokeAsync(Action action);

    /// <summary>
    /// Invokes a function on the UI thread and returns the result.
    /// </summary>
    Task<T> InvokeAsync<T>(Func<T> func);

    /// <summary>
    /// Checks if the current thread has access to the UI thread.
    /// </summary>
    bool CheckAccess();
}
