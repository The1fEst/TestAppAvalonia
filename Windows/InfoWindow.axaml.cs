using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TestApp.Windows {
    public class InfoWindow : Window {
        public InfoWindow() {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}