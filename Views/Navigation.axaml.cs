using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TestApp.Extensions;
using TestApp.Models.Constants;
using TestApp.ViewModels;

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
            var selected = (KeyValuePair<ViewEnum, string>)(navList.SelectedItem ?? new KeyValuePair<ViewEnum, string>(ViewEnum.Main, string.Empty));
            App.Navigation?.NavigateTo(selected.Key);
        }
    }
}