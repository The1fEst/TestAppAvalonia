using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TestApp.Controllers;
using TestApp.ViewModels;

namespace TestApp.Windows {
    public class MainWindow : Window {
        private MainWindowViewModel? _vm;

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

        private void OnClick(object sender, RoutedEventArgs e) {
            _vm?.PrepareAvailableItems();
        }

        protected override void OnDataContextChanged(EventArgs e) {
            base.OnDataContextChanged(e);

            _vm = DataContext as MainWindowViewModel;
        }

        private void Button_OnClick(object? sender, RoutedEventArgs e) {
            if (_vm != null) {
                _vm.Icon = _vm.IsDay
                    ? "fas fa-moon"
                    : "fas fa-sun";

                _vm.IsDay = !_vm.IsDay;
            }
        }
    }
}