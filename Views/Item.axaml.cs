using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using DynamicData;
using TestApp.Extensions;
using TestApp.Models;
using TestApp.ViewModels;

namespace TestApp.Views {
    public class Item : UserControl {
        private readonly ItemViewModel _vm;

        public Item() {
            throw new Exception();
        }

        public Item(string url) {
            DataContext = _vm = new ItemViewModel {
                Url = url
            };

            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);

            Task.Factory.StartNew(async () => await GetData(_vm.Url));
        }

        private async Task GetData(string url) {
            var data = await App.MarketClient.AsJson<ItemSpecs>($"/v1/items/{url}", HttpMethods.Get, null,
                ("Platform", "pc"), ("Language", "en"));

            foreach (var item in data.Payload.Item.ItemsInSet) {
                var link = item.UrlName.Contains("set") ? item.Icon : item.SubIcon;
                var bytes = await App.MarketStaticClient
                    .GetByteArrayAsync($"/static/assets/{link}");

                await using var iconStream = new MemoryStream(bytes);
                var icon = new Bitmap(iconStream);
                _vm.AllAvailableItems.Add(new List<NamedIcon> {new(item.En.ItemName, icon)});
            }
        }
    }
}