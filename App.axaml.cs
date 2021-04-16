using System.Net.Http;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TestApp.Controllers;
using TestApp.Models.Constants;
using TestApp.ViewModels;
using TestApp.Windows;

namespace TestApp {
    public class App : Application {
        public static NavigationController<ViewEnum>? Navigation;

        public static HttpClient MarketClient => new() {
            BaseAddress = new("https://api.warframe.market")
        };

        public static HttpClient MarketStaticClient => new() {
            BaseAddress =
                new("https://warframe.market")
        };

        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted() {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
                desktop.MainWindow = new MainWindow {
                    DataContext = new MainWindowViewModel()
                };

            base.OnFrameworkInitializationCompleted();
        }
    }
}