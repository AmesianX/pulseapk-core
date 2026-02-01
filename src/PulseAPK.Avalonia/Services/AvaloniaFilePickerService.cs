using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using PulseAPK.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PulseAPK.Avalonia.Services;

public class AvaloniaFilePickerService : IFilePickerService
{
    private IStorageProvider? GetStorageProvider()
    {
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            return desktop.MainWindow?.StorageProvider;
        }
        return null;
    }

    public async Task<string?> OpenFileAsync(string filter)
    {
        var provider = GetStorageProvider();
        if (provider == null) return null;

        var filePickerOptions = new FilePickerOpenOptions
        {
            AllowMultiple = false,
            // Simple parsing of filter string for now
            // "APK Files (*.apk)|*.apk|..."
             FileTypeFilter = ParseFilter(filter)
        };

        var result = await provider.OpenFilePickerAsync(filePickerOptions);
        return result.FirstOrDefault()?.Path.LocalPath;
    }

    public async Task<string?> OpenFolderAsync(string? initialDirectory = null)
    {
        var provider = GetStorageProvider();
        if (provider == null) return null;

        var folderPickerOptions = new FolderPickerOpenOptions();
        if (!string.IsNullOrEmpty(initialDirectory))
        {
             try 
             {
                 folderPickerOptions.SuggestedStartLocation = await provider.TryGetFolderFromPathAsync(initialDirectory);
             }
             catch {}
        }

        var result = await provider.OpenFolderPickerAsync(folderPickerOptions);
        return result.FirstOrDefault()?.Path.LocalPath;
    }
    
    private List<FilePickerFileType> ParseFilter(string filter)
    {
        // Example: "APK Files (*.apk)|*.apk|All Files (*.*)|*.*"
        // Split by |
        var parts = filter.Split('|');
        var list = new List<FilePickerFileType>();
        
        for (int i = 0; i < parts.Length; i += 2)
        {
            if (i + 1 >= parts.Length) break;
            
            var name = parts[i]; // "APK Files (*.apk)"
            var patterns = parts[i+1].Split(';'); // "*.apk"
            
            // Clean up name
            // Remove (*.ext) from name if present?
            
            var fileType = new FilePickerFileType(name)
            {
                Patterns = patterns
            };
            list.Add(fileType);
        }
        return list;
    }
}
