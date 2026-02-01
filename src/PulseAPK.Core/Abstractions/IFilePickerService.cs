namespace PulseAPK.Core.Abstractions;

/// <summary>
/// Platform-agnostic file picker service for opening files and folders.
/// </summary>
public interface IFilePickerService
{
    /// <summary>
    /// Opens a file picker dialog to select a file asynchronously.
    /// </summary>
    /// <param name="filter">File filter (e.g., "APK Files|*.apk")</param>
    /// <returns>Selected file path, or null if cancelled.</returns>
    Task<string?> OpenFileAsync(string filter);

    /// <summary>
    /// Opens a folder picker dialog to select a directory asynchronously.
    /// </summary>
    /// <param name="initialDirectory">Optional initial directory to show.</param>
    /// <returns>Selected folder path, or null if cancelled.</returns>
    Task<string?> OpenFolderAsync(string? initialDirectory = null);
}
