using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TestApp.Controllers;
using TestApp.Models.Constants;
using TestApp.ViewModels;
using TestApp.Views;

namespace TestApp.Windows {
    public class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.AttachDevTools();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);

            var workspace = this.FindControl<Grid>("Workspace");

            var views = new Dictionary<ViewEnum, Control> {
                {ViewEnum.Main, new Main()},
                {ViewEnum.Settings, new Settings()}
            };

            App.Navigation = new NavigationController<ViewEnum>(workspace, views);

            FillNavBar(views);
        }

        private void FillNavBar(Dictionary<ViewEnum, Control> views) {
            var navBar = this.FindControl<Navigation>("NavBar");

            navBar.DataContext = new NavigationViewModel {
                NavItems = views.ToDictionary(x => x.Key, x => x.Key.ToString())
            };

            var navList = navBar.FindControl<ListBox>("NavList");
            navList.SelectedIndex = 0;
        }
    }
}