namespace PulseAPK.Core.Abstractions;

/// <summary>
/// Platform-agnostic dialog service for showing messages to the user.
/// Replaces direct usage of MessageBox or platform-specific dialogs.
/// </summary>
public interface IDialogService
{
    /// <summary>
    /// Shows an informational message.
    /// </summary>
    Task ShowInfoAsync(string message, string? title = null);

    /// <summary>
    /// Shows a warning message.
    /// </summary>
    Task ShowWarningAsync(string message, string? title = null);

    /// <summary>
    /// Shows an error message.
    /// </summary>
    Task ShowErrorAsync(string message, string? title = null);

    /// <summary>
    /// Shows a question dialog with Yes/No buttons.
    /// </summary>
    /// <returns>True if user clicked Yes, false otherwise.</returns>
    Task<bool> ShowQuestionAsync(string message, string? title = null);
}
