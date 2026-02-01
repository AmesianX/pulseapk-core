using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using PulseAPK.Core.Abstractions;
using System.Threading.Tasks;

namespace PulseAPK.Avalonia.Services;

public class AvaloniaDialogService : IDialogService
{
    public async Task ShowInfoAsync(string message, string? title = null)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(title ?? "Info", message, ButtonEnum.Ok, Icon.Info);
        await box.ShowAsync();
    }

    public async Task ShowWarningAsync(string message, string? title = null)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(title ?? "Warning", message, ButtonEnum.Ok, Icon.Warning);
        await box.ShowAsync();
    }

    public async Task ShowErrorAsync(string message, string? title = null)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(title ?? "Error", message, ButtonEnum.Ok, Icon.Error);
        await box.ShowAsync();
    }

    public async Task<bool> ShowQuestionAsync(string message, string? title = null)
    {
        var box = MessageBoxManager.GetMessageBoxStandard(title ?? "Question", message, ButtonEnum.YesNo, Icon.Question);
        var result = await box.ShowAsync();
        return result == ButtonResult.Yes;
    }
}
