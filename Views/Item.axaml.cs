using System;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestApp.Extensions;
using TestApp.Models;
using TestApp.ViewModels;
using static TestApp.Utils.IconUtils;

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

            Task.Factory.StartNew(async () => await GetData());
        }

        private async Task GetData() {
            var data = await App.MarketClient.AsJson<ItemSpecs>($"/v1/items/{_vm.Url}", HttpMethods.Get, null,
                ("Platform", "pc"), ("Language", "en"));

            var itemSpec = data.Payload.Item;
            var mainItem = itemSpec.ItemsInSet.First(x => x.Id == itemSpec.Id);

            _vm.Name = mainItem.En.ItemName;
            _vm.Description = mainItem.En.Description;
            _vm.Icon = await GetIcon(GetIconUrl(mainItem));

            _vm.Items = itemSpec.ItemsInSet.Where(x => x.Id != itemSpec.Id).Select(
                item => new ListBoxItemData(item.En.ItemName, item.UrlName, GetIconUrl(item))
            ).ToList();

            await GetOrders();
        }

        private async Task GetOrders() {
            var data = await App.MarketClient.AsJson<Orders>($"/v1/items/{_vm.Url}/orders", HttpMethods.Get, null,
                ("Platform", "pc"), ("Language", "en"));

            var orders = data.Payload.Orders;

            _vm.BuyOrders = orders.Where(order => order.OrderType == "buy")
                .Select(order => new OrderItem {
                    Count = 0,
                    Platinum = order.Platinum,
                    Username = order.User.IngameName,
                }).ToList();
            
            _vm.SellOrders = orders.Where(order => order.OrderType == "sell")
                .Select(order => new OrderItem {
                    Count = 0,
                    Platinum = order.Platinum,
                    Username = order.User.IngameName,
                }).ToList();
        }
    }
}