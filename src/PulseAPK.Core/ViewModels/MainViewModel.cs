using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PulseAPK.Core.Abstractions;
using Properties = PulseAPK.Core.Properties;

namespace PulseAPK.Core.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private object _currentView;

    [ObservableProperty]
    private string _windowTitle = Properties.Resources.AppTitle;

    [ObservableProperty]
    private string _selectedMenu = "Decompile";

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        // Initial view
        CurrentView = Resolve<DecompileViewModel>();
    }

    [RelayCommand]
    private void NavigateToDecompile()
    {
        CurrentView = Resolve<DecompileViewModel>();
        SelectedMenu = "Decompile";
    }

    [RelayCommand]
    private void NavigateToSettings()
    {
        CurrentView = Resolve<SettingsViewModel>();
        SelectedMenu = "Settings";
    }

    [RelayCommand]
    private void NavigateToBuild()
    {
        CurrentView = Resolve<BuildViewModel>();
        SelectedMenu = "Build";
    }

    [RelayCommand]
    private void NavigateToAnalyser()
    {
        CurrentView = Resolve<AnalyserViewModel>();
        SelectedMenu = "Analyser";
    }

    [RelayCommand]
    private void NavigateToAbout()
    {
        CurrentView = Resolve<AboutViewModel>();
        SelectedMenu = "About";
    }

    private T Resolve<T>() where T : notnull
    {
        var service = _serviceProvider.GetService(typeof(T));
        if (service == null)
            throw new InvalidOperationException($"Could not resolve service of type {typeof(T).Name}");
        return (T)service;
    }
}
