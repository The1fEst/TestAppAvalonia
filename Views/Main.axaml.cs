using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using TestApp.Extensions;
using TestApp.Models;
using TestApp.ViewModels;

namespace TestApp.Views {
    public class Main : UserControl {
        private readonly MainViewModel _vm;

        public Main() {
            InitializeComponent();
            DataContext = _vm = new MainViewModel();
            Task.Run(async () => await GetData());
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private async Task GetData() {
            var data = await App.MarketClient.AsJson<Items>("/v1/items", HttpMethods.Get, null,
                ("Platform", "pc"), ("Language", "en"));

            _vm.AllAvailableItems.Edit(l => {
                l.Clear();

                foreach (var item in data.Payload.Items.OrderBy(x => x.ItemName))
                    l.Add(new ListBoxItemData(item.ItemName, item.UrlName, item.Thumb));
            });
        }
    }
}