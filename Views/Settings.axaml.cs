using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace TestApp.Views {
    public class Settings : UserControl {
        public Settings() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}