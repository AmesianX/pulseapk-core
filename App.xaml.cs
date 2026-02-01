using Microsoft.Extensions.DependencyInjection;
using PulseAPK.Core.Abstractions;
using PulseAPK.Core.Services;
using PulseAPK.Core.ViewModels;
using PulseAPK.Services;
using System;
using System.Windows;

namespace PulseAPK;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public IServiceProvider Services { get; private set; }

    /// <summary>
    /// Gets the current App instance.
    /// </summary>
    public new static App Current => (App)Application.Current;

    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        Services = serviceCollection.BuildServiceProvider();

        // Initialize Localization with Settings
        var settingsService = Services.GetRequiredService<ISettingsService>();
        LocalizationService.Instance.Initialize(settingsService);

        var mainWindow = Services.GetRequiredService<MainWindow>();
        mainWindow.Show();

        base.OnStartup(e);
    }

    private void ConfigureServices(IServiceCollection services)
    {
        // Core Services
        services.AddSingleton<ISettingsService, SettingsService>();
        services.AddSingleton(LocalizationService.Instance);
        services.AddTransient<ApktoolRunner>();
        services.AddTransient<UbersignRunner>();
        services.AddTransient<SmaliAnalyserService>();
        services.AddTransient<ReportService>();
        services.AddSingleton<ISystemService, PulseAPK.Core.Services.SystemService>();
        // Note: PulseAPK.Core.Services.SystemService handles opening folders/urls via Process.Start

        // WPF Platform Services
        services.AddSingleton<IDialogService, WpfDialogService>();
        services.AddSingleton<IDispatcherService, WpfDispatcherService>();
        services.AddSingleton<IFilePickerService, WpfFilePickerService>();

        // ViewModels
        services.AddSingleton<MainViewModel>();
        services.AddTransient<DecompileViewModel>();
        services.AddTransient<BuildViewModel>();
        services.AddTransient<SettingsViewModel>();
        services.AddTransient<AnalyserViewModel>();
        services.AddTransient<AboutViewModel>();

        // Views
        services.AddTransient<MainWindow>();
    }
}
