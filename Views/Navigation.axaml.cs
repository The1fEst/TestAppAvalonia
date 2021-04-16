using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestApp.Models.Constants;

namespace TestApp.Views {
    public class Navigation : UserControl {
        public Navigation() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void NavList_OnSelectionChanged(object? sender, SelectionChangedEventArgs e) {
            var navList = this.FindControl<ListBox>("NavList");
            var selected = (KeyValuePair<ViewEnum, string>) (navList.SelectedItem ??
                                                             new KeyValuePair<ViewEnum, string>(ViewEnum.Main,
                                                                 string.Empty));
            App.Navigation?.NavigateTo(selected.Key);
        }
    }
}