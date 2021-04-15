using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using TestApp.Extensions;
using TestApp.Models;
using TestApp.ViewModels;

namespace TestApp.Views {
    public class Main : UserControl {
        private MainViewModel _vm;

        public Main() {
            InitializeComponent();
            DataContext = _vm = new MainViewModel();
            Task.Factory.StartNew(async () => await GetData());
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private async Task GetData() {
            var data = await App.MarketClient.AsJson<Items>("/v1/items", HttpMethods.Get, null,
                ("Platform", "pc"), ("Language", "en"));

            _vm.PrepareAvailableItems(data.Payload.Items
                .OrderBy(x => x.ItemName)
                .Select(x => new ListBoxItemData(x.ItemName, x.UrlName)));
        }
    }
}