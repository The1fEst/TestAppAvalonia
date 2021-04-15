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
        private readonly HttpClient _client;
        private MainViewModel _vm;

        public Main() {
            _client = new HttpClient {
                BaseAddress = new("https://api.warframe.market")
            };

            InitializeComponent();
            DataContext = _vm = new MainViewModel();
            GetData();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private async Task GetData() {
            var data = await _client.AsJson<Items>("/v1/items", HttpMethods.Get, null,
                ("Platform", "pc"), ("Language", "ru"));

            _vm.PrepareAvailableItems(data.Payload.Items
                .OrderBy(x => x.ItemName)
                .Select(x => new KeyValuePair<string, string>(x.UrlName, x.ItemName)));
        }
    }
}