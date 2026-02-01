using Microsoft.Win32;
using PulseAPK.Core.Abstractions;

namespace PulseAPK.Services;

public class WpfFilePickerService : IFilePickerService
{
    public Task<string?> OpenFileAsync(string filter)
    {
        var dialog = new OpenFileDialog
        {
            Filter = filter
        };

        if (dialog.ShowDialog() == true)
        {
            return Task.FromResult<string?>(dialog.FileName);
        }
        return Task.FromResult<string?>(null);
    }

    public Task<string?> OpenFolderAsync(string? initialDirectory = null)
    {
        var dialog = new OpenFolderDialog();
        
        if (!string.IsNullOrWhiteSpace(initialDirectory))
        {
            try
            {
               dialog.InitialDirectory = initialDirectory;
            }
            catch {}
        }

        if (dialog.ShowDialog() == true)
        {
            return Task.FromResult<string?>(dialog.FolderName);
        }
        return Task.FromResult<string?>(null);
    }
}
