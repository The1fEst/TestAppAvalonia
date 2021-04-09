using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestApp.Controllers;

namespace TestApp.Views {
    public class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);

            var workspace = this.FindControl<Grid>("Workspace");
            
            App.Navigation = new NavigationController<string>(workspace);
            App.Navigation.NavigateTo("");
        }
    }
}