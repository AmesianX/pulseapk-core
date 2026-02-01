namespace PulseAPK.Core.Abstractions;

public interface ISystemService
{
    void OpenFolder(string folderPath);
    void OpenUrl(string url);
}
