using System.Diagnostics;
using System.Runtime.InteropServices;
using PulseAPK.Core.Abstractions;

namespace PulseAPK.Core.Services;

public class SystemService : ISystemService
{
    public void OpenFolder(string folderPath)
    {
        if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            return;

        OpenPath(folderPath);
    }

    public void OpenUrl(string url)
    {
        OpenPath(url);
    }

    private void OpenPath(string path)
    {
        try
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start("explorer.exe", path);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", path);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", path);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to open path '{path}': {ex.Message}");
        }
    }
}
