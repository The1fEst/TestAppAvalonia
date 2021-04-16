using Avalonia;
using Avalonia.ReactiveUI;
using Projektanker.Icons.Avalonia;
using Projektanker.Icons.Avalonia.FontAwesome;

namespace TestApp {
    internal class Program {
        public static void Main(string[] args) {
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        public static AppBuilder BuildAvaloniaApp() {
            return AppBuilder.Configure<App>()
                .AfterSetup(AfterSetupCallback)
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
        }

        private static void AfterSetupCallback(AppBuilder appBuilder) {
            IconProvider.Register<FontAwesomeIconProvider>();
        }
    }
}