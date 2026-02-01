using System.Windows;
using PulseAPK.Core.Abstractions;

namespace PulseAPK.Services;

public class WpfDialogService : IDialogService
{
    public Task ShowInfoAsync(string message, string? title = null)
    {
        MessageBox.Show(message, title ?? "Info", MessageBoxButton.OK, MessageBoxImage.Information);
        return Task.CompletedTask;
    }

    public Task ShowWarningAsync(string message, string? title = null)
    {
        MessageBox.Show(message, title ?? "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        return Task.CompletedTask;
    }

    public Task ShowErrorAsync(string message, string? title = null)
    {
        MessageBox.Show(message, title ?? "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        return Task.CompletedTask;
    }

    public Task<bool> ShowQuestionAsync(string message, string? title = null)
    {
        var result = MessageBox.Show(message, title ?? "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
        return Task.FromResult(result == MessageBoxResult.Yes);
    }
}
