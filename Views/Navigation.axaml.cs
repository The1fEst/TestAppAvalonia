using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TestApp.ViewModels;

namespace TestApp.Views {
    public class Navigation : UserControl {
        public Navigation() {
            InitializeComponent();

            DataContext = new NavigationViewModel {
                NavItems = new() {
                    {"test1Key", () => Console.WriteLine("test1Key")},
                    {"test2Key", () => Console.WriteLine("test2Key")},
                    {"test3Key", () => Console.WriteLine("test3Key")},
                    {"test4Key", () => Console.WriteLine("test4Key")},
                }
            };
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void NavList_OnDoubleTapped(object? sender, RoutedEventArgs e) {
            var navList = this.FindControl<ListBox>("NavList");
            Console.WriteLine(navList.SelectedItem);
        }
    }
}